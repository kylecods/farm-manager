using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FactoryService : IFactoryService
    {
        private readonly IFactoryRepository _factoryRepository;

        public FactoryService(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        public async Task AddFactoryAsync(FactoryModel item)
        {  
            await _factoryRepository.AddAsync(item);
        }

        public async Task DeleteFactoryAsync(Guid id)
        {
            await _factoryRepository.DeleteAsync(id);
        }

        public async Task<List<FactoryModel>> GetAllFactoriesAsync()
        {
            var factories = await _factoryRepository.GetAllAsync();

            return factories.ToList();
        }

        public async Task<FactoryModel> GetFactoryByIdAsync(Guid id)
        {
            return await _factoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateFactoryAsync(FactoryModel item)
        {
            await _factoryRepository.UpdateAsync(item); 
        }
    }
}
