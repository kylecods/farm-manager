using Entities.Models;

namespace Services
{
    public interface IFactoryService
    {
        Task AddFactoryAsync(FactoryModel item);

        Task UpdateFactoryAsync(FactoryModel item);

        Task DeleteFactoryAsync(Guid id);

        Task<List<FactoryModel>> GetAllFactoriesAsync();

        Task<FactoryModel> GetFactoryByIdAsync(Guid id);
    }
}