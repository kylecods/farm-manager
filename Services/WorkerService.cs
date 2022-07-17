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
        public Task AddWorkerAsync(WorkerModel item)
        {
            return _workerRepository.AddAsync(item);
        }

        public Task AddWorkerTrackerAsync(WorkerTrackerModel item)
        {
            return _workerTrackerRepository.AddAsync(item);
        }

        public Task DeleteWorkerAsync(Guid id)
        {
            return _workerRepository.DeleteAsync(id);
        }

        public Task DeleteWorkerTrackerAsync(Guid id)
        {
            return _workerTrackerRepository.DeleteAsync(id);
        }

        public async Task<List<WorkerModel>> GetAllWorkersAsync()
        {
            var workers = await _workerRepository.GetAllAsync();
            
            return workers.ToList();
        }

        public async Task<List<WorkerTrackerModel>> GetAllWorkerTrackersAsync()
        {
            var workerTrackers = await _workerTrackerRepository.GetAllAsync();

            return workerTrackers.ToList();
        }

        public Task<WorkerModel> GetWorkerByIdAsync(Guid id)
        {
            return _workerRepository.GetByIdAsync(id);
        }

        public Task<WorkerTrackerModel> GetWorkerTrackerByIdAsync(Guid id)
        {
            return _workerTrackerRepository.GetByIdAsync(id);
        }

        public Task UpdateWorkerAsync(WorkerModel item)
        {
            return _workerRepository.UpdateAsync(item);
        }

        public Task UpdateWorkerTrackerAsync(WorkerTrackerModel item)
        {
            return _workerTrackerRepository.UpdateAsync(item);
        }
    }
}
