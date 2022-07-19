using AutoMapper;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Repositories.Mappers;

namespace Repositories
{
    public class FactoryCollectionRepository : IFactoryCollectionsRepository
    {
        private readonly FarmDbContext _dbContext;

        private readonly IMapper _mapper;
        public FactoryCollectionRepository(FarmDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentException();

            _mapper = mapper ?? throw new ArgumentException();
        }
        public async Task AddAsync(FactoryCollectionModel item)
        {
            var factoryCollection = FactoryCollectionMapper.CreateFactoryCollection(item);

            await _dbContext.AddAsync(factoryCollection!);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.FactoryCollections.FindAsync(id);

            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<FactoryCollectionModel>> GetAllAsync()
        {
            var result = _dbContext.FactoryCollections;

            var mappedResult = _mapper.Map<IEnumerable<FactoryCollection>, IEnumerable<FactoryCollectionModel>>(result!);

            return await Task.FromResult(mappedResult);
        }

        public async Task<FactoryCollectionModel> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.FactoryCollections.FindAsync(id);

            var mappedEntity = _mapper.Map<FactoryCollectionModel>(entity);

            return mappedEntity;
        }

        public async Task UpdateAsync(FactoryCollectionModel item)
        {
            var entity = await _dbContext.FactoryCollections.FindAsync(item.Id);

            if (entity != null)
            {
                entity.UpdateFactoryCollection(item);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
