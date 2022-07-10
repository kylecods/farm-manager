using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FactoryCollectionRepository : IFactoryCollectionsRepository
    {
        private readonly FarmDbContext _dbContext;
        public FactoryCollectionRepository(FarmDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException();
        }
        public Task AddAsync(FactoryCollection item)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.FactoryCollections.FindAsync(id);

            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<FactoryCollection>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.FactoryCollections);
        }

        public Task<FactoryCollection> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FactoryCollection item)
        {
            throw new NotImplementedException();
        }
    }
}
