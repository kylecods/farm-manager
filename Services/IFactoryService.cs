using Entities.Models;

namespace Services
{
    public interface IFactoryService
    {
        ValueTask AddFactoryAsync(FactoryModel item);

        ValueTask UpdateFactoryAsync(FactoryModel item);

        ValueTask DeleteFactoryAsync(Guid id);

        ValueTask<List<FactoryModel>> GetAllFactoriesAsync();

        ValueTask<FactoryModel> GetFactoryByIdAsync(Guid id);



        ValueTask AddFactoryCollectionAsync(FactoryCollectionModel item);

        ValueTask UpdateFactoryCollectionAsync(FactoryCollectionModel item);

        ValueTask DeleteFactoryCollectionAsync(Guid id);

        ValueTask<List<FactoryCollectionModel>> GetAllFactoryCollectionsAsync();

        ValueTask<FactoryCollectionModel> GetFactoryCollectionByIdAsync(Guid id);

        ValueTask<List<FactoryCollectionModel>> GetAllFactoryCollectionsByFactoryId(Guid factoryId);
    }
}