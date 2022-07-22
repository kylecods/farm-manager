using Entities.Models;

namespace Repositories
{
    public interface IWorkerTrackerRepository : IRepository<WorkerTrackerModel, Guid>
    {
        ValueTask<IEnumerable<WorkerTrackerModel>> GetAllByWorkerIdAsync(Guid workerId);
    }
}
