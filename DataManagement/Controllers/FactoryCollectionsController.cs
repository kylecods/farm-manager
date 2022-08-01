using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Services;

namespace DataManagement.Controllers
{
    public class FactoryCollectionsController : Controller
    {
        private readonly IFactoryService _factoryService;
        private readonly IAccountsService _accountsService;

        public FactoryCollectionsController(IFactoryService factoryService, IAccountsService accountsService)
        {
            _factoryService = factoryService;
            _accountsService = accountsService;
        }

        // GET: FactoryCollectionsController
        public async ValueTask<ActionResult> Index(Guid id)
        {
            var factory = await _factoryService.GetFactoryByIdAsync(id);

            var data = await _factoryService.GetAllFactoryCollectionsByFactoryId(id);

            ViewBag.FactoryName = factory.FactoryName;

            ViewBag.TotalAmount = data.Sum(x => x.AmountPaid).ToString("F");

            return View();
        }

        public async ValueTask<JsonResult> GetFactoryCollectionData()
        {
            var data = await _factoryService.GetAllFactoryCollectionsAsync();

            return Json(data ?? new List<FactoryCollectionModel>());
        }

        public async ValueTask<JsonResult> GetFactoryCollectionDataByFactoryId(Guid id)
        {
            var data = await _factoryService.GetAllFactoryCollectionsByFactoryId(id);

            return Json(data ?? new List<FactoryCollectionModel>());
        }

        // GET: FactoryCollectionsController/Create
        public async ValueTask<ActionResult> Create(Guid id)
        {
            var factory = await _factoryService.GetFactoryByIdAsync(id);

            var factoryCollection = new FactoryCollectionModel();

            factoryCollection.FactoryId = factory.Id;

            factoryCollection.PaidDate = DateTime.Now;

            return View(factoryCollection);
        }

        // POST: FactoryCollectionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(FactoryCollectionModel model)
        {
            try
            {

                var account = await _accountsService.GetAccountByActivityAsync(Activities.FactoryIncome);

                await _factoryService.AddFactoryCollectionAsync(model);

                var addToRegister = new RegisterModel()
                {
                    AccountsId = account!.Id,
                    Activity = account!.Activity,
                    AccountType = account!.AccountType,
                    Amount = model.AmountPaid,
                    Date =  model.PaidDate
                };

                await _accountsService.AddRegisterAsync(addToRegister);

                TempData["Success"] = "Collection information added";

                return Redirect($"/factorycollections/index/{model.FactoryId}");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return Redirect($"/factorycollections/index/{model.FactoryId}");
            }
        }

        // GET: FactoryCollectionsController/Edit/5
        public async ValueTask<ActionResult> Edit(Guid id)
        {
            var factoryCollection = await _factoryService.GetFactoryCollectionByIdAsync(id);

            return View(factoryCollection);
        }

        // POST: FactoryCollectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Edit(FactoryCollectionModel model)
        {
            try
            {
                await _factoryService.UpdateFactoryCollectionAsync(model);

                TempData["Success"] = "Collection information updated.";

                return Redirect($"/factorycollections/index/{model.FactoryId}");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return Redirect($"/factorycollections/index/{model.FactoryId}");
            }
        }

        // POST: FactoryCollectionsController/Delete/5
        [HttpPost]
        public async ValueTask<ActionResult> Delete(string id)
        {
            try
            {
                await _factoryService.DeleteFactoryCollectionAsync(Guid.Parse(id));

                return Json(new { message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { message = $"Failed. {ex.Message}" });
            }
        }

    }
}
