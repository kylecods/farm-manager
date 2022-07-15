using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace DataManagement.Controllers
{
    public class FactoryController : Controller
    {
        private readonly IFactoryService _factoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }
        // GET: FactoryController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<JsonResult> GetAllData()
        {
            var data = await _factoryService.GetAllFactoriesAsync();

            return Json(data.ToList());
        }

        // GET: FactoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FactoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(FactoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _factoryService.AddFactoryAsync(model);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return View();
            
        }

        // GET: FactoryController/Edit/5
        public async ValueTask<ActionResult> Edit(Guid id)
        {
            var factory = await _factoryService.GetFactoryByIdAsync(id);

            return View(factory);
        }

        // POST: FactoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Edit(FactoryModel model)
        {
            try
            {
                await _factoryService.UpdateFactoryAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FactoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
