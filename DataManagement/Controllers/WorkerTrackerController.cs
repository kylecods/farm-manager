using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async ValueTask<ActionResult> Index(Guid id)
        {
            var worker = await _workerService.GetWorkerByIdAsync(id);

            ViewBag.Name = worker!.WorkerName;

            return View();
        }

        public async ValueTask<JsonResult> GetTrackedWorkerData()
        {
            var data = await _workerService.GetAllWorkerTrackersAsync();

            return Json(data ?? new List<WorkerTrackerModel>());
        }

        public async ValueTask<JsonResult> GetTrackedWorkerDataByWorkerId(string id)
        {
            var data = await _workerService.GetAllWorkerTrackersByWorkerIdAsync(Guid.Parse(id));

            return Json(data ?? new List<WorkerTrackerModel>());
        }

        // GET: WorkerTrackerController/Create
        public async ValueTask<ActionResult> Create(Guid id)
        {
            var trackedWorker = await _workerService.GetWorkerByIdAsync(id!);

            var workerTracker = new WorkerTrackerModel();

            workerTracker.PickedDate = DateTime.Now;

            workerTracker.WorkerId = trackedWorker.Id; 

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

                return Redirect($"/workerTracker/index/{model.WorkerId}");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return RedirectToAction($"/workerTracker/index/{model.WorkerId}");
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

                return Redirect($"/workerTracker/index/{model.WorkerId}");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return Redirect($"/workerTracker/index/{model.WorkerId}");
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
