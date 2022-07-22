using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services;
using Entities.Models;
using System;
using System.Linq;

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

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["Errors"] = $"Failed. {ex.Message}";

                return View();
            }
        }

        public IActionResult AccountRegister(Guid id)
        {
            return View();
        }

        [HttpPost]
        public async ValueTask<JsonResult> GetRegisters(Guid id)
        {
            var registers = await _accountsService.GetRegistersByAccountId(id);

            return Json(registers ?? Enumerable.Empty<RegisterModel>());
        }

    }
}
