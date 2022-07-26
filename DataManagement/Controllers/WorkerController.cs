﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.Extensions.Logging;


namespace DataManagement.Controllers
{
    [Authorize]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;

        private readonly ILogger<WorkerController> _logger;

        public WorkerController(IWorkerService workerService,ILogger<WorkerController> logger)
        {
            _workerService = workerService;

            _logger = logger;
        }
        // GET: WorkerController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<JsonResult> GetAllWorkers()
        {
            var data = await _workerService.GetAllWorkersAsync();

            return Json(data ?? new List<WorkerModel>());
        }


        // GET: WorkerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(WorkerModel model)
        {
            try
            {
                await _workerService.AddWorkerAsync(model);

                TempData["Success"] = "Worker added.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                _logger.LogError(ex, "Worker Create => Something went horribly wrong");

                return View(model);
            }
        }

        // GET: WorkerController/Edit/5
        public async ValueTask<ActionResult> Edit(Guid id)
        {
            var worker = await _workerService.GetWorkerByIdAsync(id);

            return View(worker!);
        }

        // POST: WorkerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Edit(WorkerModel model)
        {
            try
            {
                await _workerService.UpdateWorkerAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return View(model);
            }
        }


        // POST: WorkerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Delete(WorkerModel model)
        {
            try
            {
                await _workerService.DeleteWorkerAsync(model.Id);

                return Json(new { message = "Success" });
            }
            catch
            {
                return Json(new { message = "Failed" });
            }
        }
    }
}
