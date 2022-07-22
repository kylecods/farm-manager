using AutoMapper;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Repositories.Mappers;

namespace Repositories
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly FarmDbContext _dbContext;
        private readonly IMapper _mapper;

        public FactoryRepository(FarmDbContext dbcontext, IMapper mapper)
        {

            _dbContext = dbcontext ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public virtual async ValueTask AddAsync(FactoryModel item)
        {
            var factory = FactoryMapper.CreateFactory(item);

            await _dbContext.AddAsync(factory!);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async ValueTask DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Factories.FindAsync(id);

            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async ValueTask<IEnumerable<FactoryModel>> GetAllAsync()
        {
            var result = _dbContext.Factories;

            var mappedResult = _mapper.Map<IEnumerable<Factory>, IEnumerable<FactoryModel>>(result!);

            return await ValueTask.FromResult(mappedResult);
        }

        public virtual async ValueTask<FactoryModel> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Factories.FindAsync(id);

            var mappedEntity = _mapper.Map<FactoryModel>(entity);

            return mappedEntity ?? new FactoryModel();
        }

        public virtual async ValueTask UpdateAsync(FactoryModel item)
        {
            var entity = await _dbContext.Factories.FindAsync(item.Id);

            if (entity != null)
            {
                entity.UpdateFactory(item);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
