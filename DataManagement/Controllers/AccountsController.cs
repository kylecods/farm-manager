using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace DataManagement.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;

        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IAccountsService accountsService, ILogger<AccountsController> logger)
        {
            _accountsService = accountsService;

            _logger = logger;
        }
        // GET: AccountsController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountsService.GetAllAccountsAsync();

            return Json(accounts ?? Enumerable.Empty<AccountsModel>());
        }

        // GET: AccountsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(AccountsModel model)
        {
            try
            {
                await _accountsService.AddAccountsAsync(model);

                TempData["Success"] = "Accounts created successfully";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["Errors"] = $"Failed. {ex.Message}";

                _logger.LogError(ex, "Accounts Create => Something went horribly wrong");

                return View();
            }
        }

        public async ValueTask<IActionResult> AccountRegister(Guid id)
        {
            var account = await _accountsService.GetAccountByIdAsync(id);

            var registers = await _accountsService.GetRegistersByAccountId(id);

            ViewBag.AccountsName = account.AccountDesc;

            ViewBag.Activity = account.Activity;

            ViewBag.TotalAmount = registers.Sum(x => x.Amount + account.StartAmount).ToString("F");

            return View();
        }

        public async ValueTask<JsonResult> GetRegisters(Guid id)
        {
            var registers = await _accountsService.GetRegistersByAccountId(id);

            return Json(registers ?? Enumerable.Empty<RegisterModel>());
        }

    }
}
