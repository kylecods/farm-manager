using Entities.Models;

namespace Repositories
{
    public interface IWorkerTrackerRepository : IRepository<WorkerTrackerModel, Guid>
    {
        Task<IEnumerable<WorkerTrackerModel>> GetAllByWorkerIdAsync(Guid workerId);
    }
}
