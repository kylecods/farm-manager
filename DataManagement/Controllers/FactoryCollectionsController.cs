using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;

namespace DataManagement.Controllers
{
    public class FactoryCollectionsController : Controller
    {
        private readonly IFactoryService _factoryService;

        public FactoryCollectionsController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        // GET: FactoryCollectionsController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<JsonResult> GetFactoryCollectionData()
        {
            var data = await _factoryService.GetAllFactoryCollectionsAsync();

            return Json(data ?? new List<FactoryCollectionModel>());
        }

        // GET: FactoryCollectionsController/Create
        public async ValueTask<ActionResult> Create()
        {
            var factoryCollection = new FactoryCollectionModel();

            var factories = await GetFactories();

            factoryCollection.Factories = new List<SelectListItem>();

            factoryCollection.PaidDate = DateTime.Now;

            foreach (var factory in factories)
            {
                var item = new SelectListItem()
                {
                    Value = factory.Id.ToString(),
                    Text = factory.FactoryName
                };
                factoryCollection.Factories.Add(item);
            }

            return View(factoryCollection);
        }

        // POST: FactoryCollectionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(FactoryCollectionModel model)
        {
            try
            {
                await _factoryService.AddFactoryCollectionAsync(model);

                TempData["Success"] = "Collection information added";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return RedirectToAction(nameof(Index));
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

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return RedirectToAction(nameof(Index));
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
        [NonAction]
        private ValueTask<List<FactoryModel>> GetFactories()
        {
            return _factoryService.GetAllFactoriesAsync();
        }
    }
}
