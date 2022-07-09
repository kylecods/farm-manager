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
            var factory = FactoryHelper.GenerateNewFactoryModel(item);

            await _dbContext.AddAsync(factory);

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

            return entity ?? new FactoryModel();
        }

        public async Task UpdateAsync(FactoryModel item)
        {
            var entity = await _dbContext.Factories.FindAsync(item.Id);

            if(entity != null)
            {
                entity.Weight = item.Weight;
                entity.FactoryName = item.FactoryName;
                entity.AmountPaid = item.AmountPaid;
                entity.PaidDate = item.PaidDate;

               await _dbContext.SaveChangesAsync();
            }
        }
    }
}
