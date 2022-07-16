using Entities.Models;
using Repositories;

namespace Services
{
    public class FactoryService : IFactoryService
    {
        private readonly IFactoryRepository _factoryRepository;

        private readonly IFactoryCollectionsRepository _factoryCollectionsRepository;

        public FactoryService(IFactoryRepository factoryRepository, IFactoryCollectionsRepository factoryCollectionsRepository)
        {
            _factoryRepository = factoryRepository;

            _factoryCollectionsRepository = factoryCollectionsRepository;
        }

        public Task AddFactoryAsync(FactoryModel item)
        {  
             return _factoryRepository.AddAsync(item);
        }

        public Task AddFactoryCollectionAsync(FactoryCollectionModel item)
        {
            return _factoryCollectionsRepository.AddAsync(item);
        }

        public Task DeleteFactoryAsync(Guid id)
        {
            return _factoryRepository.DeleteAsync(id);
        }

        public Task DeleteFactoryCollectionAsync(Guid id)
        {
            return _factoryCollectionsRepository.DeleteAsync(id);
        }

        public async Task<List<FactoryModel>> GetAllFactoriesAsync()
        {
            var factories = await _factoryRepository.GetAllAsync();

            return factories.ToList();
        }

        public async Task<List<FactoryCollectionModel>> GetAllFactoryCollectionsAsync()
        {
            var factoryCollections = await _factoryCollectionsRepository.GetAllAsync();

            return factoryCollections.ToList();
        }

        public Task<FactoryModel> GetFactoryByIdAsync(Guid id)
        {
            return _factoryRepository.GetByIdAsync(id);
        }

        public Task<FactoryCollectionModel> GetFactoryCollectionByIdAsync(Guid id)
        {
            return _factoryCollectionsRepository.GetByIdAsync(id);
        }

        public Task UpdateFactoryAsync(FactoryModel item)
        {
            return _factoryRepository.UpdateAsync(item); 
        }

        public Task UpdateFactoryCollectionAsync(FactoryCollectionModel item)
        {
            return _factoryCollectionsRepository.UpdateAsync(item);
        }
    }
}
