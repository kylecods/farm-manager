using Entities.Models;

namespace Repositories
{
    public interface IRegisterRepository : IRepository<RegisterModel,Guid>
    {
        ValueTask<IEnumerable<RegisterModel>> GetAllByAccountIdAsync(Guid accountId);
    }
}
