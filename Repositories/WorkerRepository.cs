using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        public Task AddAsync(Worker item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Worker>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Worker> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Worker item)
        {
            throw new NotImplementedException();
        }
    }
}
