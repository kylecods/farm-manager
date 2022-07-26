using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services;
using Entities.Models;


namespace DataManagement.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
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

                return View();
            }
        }

        public async ValueTask<IActionResult> AccountRegister(Guid id)
        {
            var account = await _accountsService.GetAccountByIdAsync(id);

            ViewBag.AccountsName = account.AccountDesc;

            return View();
        }

        public async ValueTask<JsonResult> GetRegisters(Guid id)
        {
            var registers = await _accountsService.GetRegistersByAccountId(id);

            return Json(registers ?? Enumerable.Empty<RegisterModel>());
        }

    }
}
