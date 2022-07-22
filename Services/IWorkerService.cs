using Entities.Models;

namespace Services
{
    public interface IWorkerService
    {
        ValueTask AddWorkerAsync(WorkerModel item);

        ValueTask UpdateWorkerAsync(WorkerModel item);

        ValueTask DeleteWorkerAsync(Guid id);

        ValueTask<List<WorkerModel>> GetAllWorkersAsync();

        ValueTask<WorkerModel> GetWorkerByIdAsync(Guid id);


        ValueTask AddWorkerTrackerAsync(WorkerTrackerModel item);

        ValueTask UpdateWorkerTrackerAsync(WorkerTrackerModel item);

        ValueTask DeleteWorkerTrackerAsync(Guid id);

        ValueTask<List<WorkerTrackerModel>> GetAllWorkerTrackersAsync();

        ValueTask<List<WorkerTrackerModel>> GetAllWorkerTrackersByWorkerIdAsync(Guid workerId);

        ValueTask<WorkerTrackerModel> GetWorkerTrackerByIdAsync(Guid id);
    }
}
