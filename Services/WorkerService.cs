using Entities.Models;
using Repositories;

namespace Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        private readonly IWorkerTrackerRepository _workerTrackerRepository;
        public WorkerService(IWorkerRepository workerRepository, IWorkerTrackerRepository workerTrackerRepository)
        {
            _workerRepository = workerRepository;

            _workerTrackerRepository = workerTrackerRepository;
        }
        public ValueTask AddWorkerAsync(WorkerModel item)
        {
            return _workerRepository.AddAsync(item);
        }

        public ValueTask AddWorkerTrackerAsync(WorkerTrackerModel item)
        {
            return _workerTrackerRepository.AddAsync(item);
        }

        public ValueTask DeleteWorkerAsync(Guid id)
        {
            return _workerRepository.DeleteAsync(id);
        }

        public ValueTask DeleteWorkerTrackerAsync(Guid id)
        {
            return _workerTrackerRepository.DeleteAsync(id);
        }

        public async ValueTask<List<WorkerModel>> GetAllWorkersAsync()
        {
            var workers = await _workerRepository.GetAllAsync();

            return workers.ToList();
        }

        public async ValueTask<List<WorkerTrackerModel>> GetAllWorkerTrackersAsync()
        {
            var workerTrackers = await _workerTrackerRepository.GetAllAsync();

            return workerTrackers.ToList();
        }

        public async ValueTask<List<WorkerTrackerModel>> GetAllWorkerTrackersByWorkerIdAsync(Guid workerId)
        {
            var workerTrackers = await _workerTrackerRepository.GetAllByWorkerIdAsync(workerId);

            return workerTrackers.ToList();
        }

        public ValueTask<WorkerModel> GetWorkerByIdAsync(Guid id)
        {
            return _workerRepository.GetByIdAsync(id);
        }

        public ValueTask<WorkerTrackerModel> GetWorkerTrackerByIdAsync(Guid id)
        {
            return _workerTrackerRepository.GetByIdAsync(id);
        }

        public ValueTask UpdateWorkerAsync(WorkerModel item)
        {
            return _workerRepository.UpdateAsync(item);
        }

        public ValueTask UpdateWorkerTrackerAsync(WorkerTrackerModel item)
        {
            return _workerTrackerRepository.UpdateAsync(item);
        }
    }
}
