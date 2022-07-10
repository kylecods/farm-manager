using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class WorkerTrackerRepository : IWorkerTrackerRepository
    {
        public Task AddAsync(WorkerTracker item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkerTracker>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WorkerTracker> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkerTracker item)
        {
            throw new NotImplementedException();
        }
    }
}
