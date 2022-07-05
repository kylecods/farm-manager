using DomainLayer;

namespace DataLayer
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly FactoryDbContext _dbContext;

        public FactoryRepository(FactoryDbContext dbcontext){

            _dbContext = dbcontext ?? throw new ArgumentNullException();
        }

        public virtual async Task AddAsync(FactoryModel item)
        {
            await _dbContext.AddAsync(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Factories.FindAsync(id);

            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FactoryModel>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Factories.ToList()); 
        }

        public async Task<FactoryModel> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Factories.FindAsync(id);

            return  entity?.ToFactory();
        }

        public async Task UpdateAsync(FactoryModel item)
        {
            var entity = await _dbContext.Factories.FindAsync(item.Id);

            if(entity != null)
            {
                entity.Load(item);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
