using Entities.Models;

namespace Repositories
{
    public interface IFactoryCollectionsRepository : IRepository<FactoryCollectionModel, Guid>
    {
        ValueTask<IEnumerable<FactoryCollectionModel>> GetAllByFactoryIdAsync(Guid factoryId);
    }
}
