using Repositories;
using Entities.Models;

namespace Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;

        private readonly IRegisterRepository _registerRepository;
        public AccountsService(IAccountsRepository accountsRepository, IRegisterRepository registerRepository)
        {
            _accountsRepository = accountsRepository;

            _registerRepository = registerRepository;
        }
        public ValueTask AddAccountsAsync(AccountsModel item)
        {
            return _accountsRepository.AddAsync(item);
        }

        public ValueTask AddRegisterAsync(RegisterModel item)
        {
            return _registerRepository.AddAsync(item);
        }

        public ValueTask<AccountsModel> GetAccountByIdAsync(Guid id)
        {
            return _accountsRepository.GetByIdAsync(id);
        }

        public async ValueTask<List<AccountsModel>> GetAllAccountsAsync()
        {
            var accounts = await _accountsRepository.GetAllAsync();

            return accounts.ToList();
        }

        public async ValueTask<List<RegisterModel>> GetAllRegistersAsync()
        {
            var registers = await _registerRepository.GetAllAsync();

            return registers.ToList();
        }

        public ValueTask<RegisterModel> GetRegisterByIdAsync(Guid id)
        {
            return _registerRepository.GetByIdAsync(id);
        }

        public async ValueTask<List<RegisterModel>> GetRegistersByAccountId(Guid accountId)
        {
            var registers = await _registerRepository.GetAllByAccountIdAsync(accountId);

            return registers.ToList();
        }
    }
}
