using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Services;
using Microsoft.AspNetCore.Authorization;

namespace DataManagement.Controllers
{
    [Authorize]
    public class WorkerTrackerController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IAccountsService _accountsService;
        private readonly ILogger<WorkerTrackerController> _logger;

        public WorkerTrackerController(IWorkerService workerService, IAccountsService accountsService,ILogger<WorkerTrackerController> logger)
        {
            _workerService = workerService;

            _accountsService = accountsService; 

            _logger = logger;
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

                var account = await _accountsService.GetAccountByActivityAsync(model.Activity);

                var amount = 0m;

                if(model.Activity == Activities.Plucking)
                {
                    amount = model.KiloGramsPicked * model.AmountPaid;
                }
                else
                {
                    amount = model.AmountPaid;
                }

                var addToRegister = new RegisterModel()
                {
                    AccountsId = account.Id,
                    Activity = model.Activity,
                    AccountType = account.AccountType,
                    Amount = amount,
                    Date = model.PickedDate
                };

                await _accountsService.AddRegisterAsync(addToRegister);

                _logger.LogInformation("Created register model => {0}", JsonSerializer.Serialize(addToRegister));

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
