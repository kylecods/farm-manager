using Entities.Models;

namespace Repositories
{
    public interface IAccountsRepository : IRepository<AccountsModel,Guid>
    {
        ValueTask<AccountsModel> GetByActivityAsync(Activities activity);
    }
}
