﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services
{
    public interface IWorkerService
    {
        Task AddWorkerAsync(WorkerModel item);

        Task UpdateWorkerAsync(WorkerModel item);

        Task DeleteWorkerAsync(Guid id);

        Task<List<WorkerModel>> GetAllWorkersAsync();

        Task<WorkerModel> GetWorkerByIdAsync(Guid id);


        Task AddWorkerTrackerAsync(WorkerTrackerModel item);

        Task UpdateWorkerTrackerAsync(WorkerTrackerModel item);

        Task DeleteWorkerTrackerAsync(Guid id);

        Task<List<WorkerTrackerModel>> GetAllWorkerTrackersAsync();

        Task<WorkerTrackerModel> GetWorkerTrackerByIdAsync(Guid id);
    }
}