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

        public ValueTask AddFactoryAsync(FactoryModel item)
        {
            return _factoryRepository.AddAsync(item);
        }

        public ValueTask AddFactoryCollectionAsync(FactoryCollectionModel item)
        {
            return _factoryCollectionsRepository.AddAsync(item);
        }

        public ValueTask DeleteFactoryAsync(Guid id)
        {
            return _factoryRepository.DeleteAsync(id);
        }

        public ValueTask DeleteFactoryCollectionAsync(Guid id)
        {
            return _factoryCollectionsRepository.DeleteAsync(id);
        }

        public async ValueTask<List<FactoryModel>> GetAllFactoriesAsync()
        {
            var factories = await _factoryRepository.GetAllAsync();

            return factories.ToList();
        }

        public async ValueTask<List<FactoryCollectionModel>> GetAllFactoryCollectionsAsync()
        {
            var factoryCollections = await _factoryCollectionsRepository.GetAllAsync();

            return factoryCollections.ToList();
        }

        public async ValueTask<List<FactoryCollectionModel>> GetAllFactoryCollectionsByFactoryId(Guid factoryId)
        {
            var factoryCollections = await _factoryCollectionsRepository.GetAllByFactoryIdAsync(factoryId);

            return factoryCollections.ToList();
        }

        public ValueTask<FactoryModel> GetFactoryByIdAsync(Guid id)
        {
            return _factoryRepository.GetByIdAsync(id);
        }

        public ValueTask<FactoryCollectionModel> GetFactoryCollectionByIdAsync(Guid id)
        {
            return _factoryCollectionsRepository.GetByIdAsync(id);
        }

        public ValueTask UpdateFactoryAsync(FactoryModel item)
        {
            return _factoryRepository.UpdateAsync(item);
        }

        public ValueTask UpdateFactoryCollectionAsync(FactoryCollectionModel item)
        {
            return _factoryCollectionsRepository.UpdateAsync(item);
        }
    }
}
