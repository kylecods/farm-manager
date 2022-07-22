using Entities.Models;


namespace Services
{
    public interface IAccountsService
    {
        ValueTask AddAccountsAsync(AccountsModel item);

        ValueTask<List<AccountsModel>> GetAllAccountsAsync();

        ValueTask<AccountsModel> GetAccountByIdAsync(Guid id);


        ValueTask AddRegisterAsync(RegisterModel item);

        ValueTask<List<RegisterModel>> GetAllRegistersAsync();

        ValueTask<RegisterModel> GetRegisterByIdAsync(Guid id);

        ValueTask<List<RegisterModel>> GetRegistersByAccountId(Guid accountId);

    }
}
