using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;

namespace DataManagement.Controllers
{
    public class WorkerTrackerController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkerTrackerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        // GET: WorkerTrackerController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<JsonResult> GetTrackedWorkerData()
        {
            var data = await _workerService.GetAllWorkerTrackersAsync();

            return Json(data ?? new List<WorkerTrackerModel>());
        }

        // GET: WorkerTrackerController/Create
        public async ValueTask<ActionResult> Create()
        {
            var workerTracker = new WorkerTrackerModel();

            var workers = await _workerService.GetAllWorkersAsync();

            workerTracker.Workers = new List<SelectListItem>();


            foreach (var worker in workers)
            {
                var item = new SelectListItem()
                {
                    Value = worker.Id.ToString(),
                    Text = worker.WorkerName
                };
                workerTracker.Workers.Add(item);
            }

            return View(workerTracker);
        }

        // POST: WorkerTrackerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(WorkerTrackerModel model)
        {
            try
            {
                await _workerService.AddWorkerTrackerAsync(model);

                TempData["Success"] = "Tracked worker information added.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: WorkerTrackerController/Edit/5
        public async ValueTask<ActionResult> Edit(Guid id)
        {
            var trackedWorker = await _workerService.GetWorkerTrackerByIdAsync(id);

            return View(trackedWorker!);
        }

        // POST: WorkerTrackerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Edit(WorkerTrackerModel model)
        {
            try
            {
                await _workerService.UpdateWorkerTrackerAsync(model);

                TempData["Success"] = $"Tracked worker information updated.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return RedirectToAction(nameof(Index));
            }
        }


        // POST: WorkerTrackerController/Delete/5
        [HttpPost]
        public async ValueTask<ActionResult> Delete(string id)
        {
            try
            {
                await _workerService.DeleteWorkerTrackerAsync(Guid.Parse(id));

                return Json(new { message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { message = $"Failed. {ex.Message}" });
            }
        }
    }
}
