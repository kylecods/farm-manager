using Entities.Models;
using Repositories;
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

        public Task AddFactoryAsync(FactoryModel item)
        {  
             return _factoryRepository.AddAsync(item);
        }

        public Task DeleteFactoryAsync(Guid id)
        {
            return _factoryRepository.DeleteAsync(id);
        }

        public async Task<List<FactoryModel>> GetAllFactoriesAsync()
        {
            var factories = await _factoryRepository.GetAllAsync();

            return factories.ToList();
        }

        public Task<FactoryModel> GetFactoryByIdAsync(Guid id)
        {
            return _factoryRepository.GetByIdAsync(id);
        }

        public Task UpdateFactoryAsync(FactoryModel item)
        {
            return _factoryRepository.UpdateAsync(item); 
        }
    }
}
