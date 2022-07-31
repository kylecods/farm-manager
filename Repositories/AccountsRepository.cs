using AutoMapper;
using Entities;
using Entities.Models;
using Repositories.Mappers;

namespace Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly FarmDbContext _farmDbContext;

        private readonly IMapper _mapper;

        public AccountsRepository(FarmDbContext farmDbContext, IMapper mapper)
        {
            _farmDbContext = farmDbContext ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public async ValueTask AddAsync(AccountsModel item)
        {
            var accounts = AccountsMapper.CreateAccounts(item);

            await _farmDbContext.AddAsync(accounts!);

            await _farmDbContext.SaveChangesAsync();
        }

        public ValueTask DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IEnumerable<AccountsModel>> GetAllAsync()
        {
            var result = _farmDbContext.Accounts;

            var mappedResult = _mapper.Map<IEnumerable<Accounts>, IEnumerable<AccountsModel>>(result);

            return await ValueTask.FromResult(mappedResult);
        }

        public async ValueTask<AccountsModel> GetByActivityAsync(Activities activity)
        {
            var entity = _farmDbContext.Accounts.Where(x => x.Activity == activity).SingleOrDefault();

            var mappedEntity = _mapper.Map<AccountsModel>(entity);

            return await ValueTask.FromResult(mappedEntity ?? new AccountsModel());
        }

        public async ValueTask<AccountsModel> GetByIdAsync(Guid id)
        {
            var entity = await _farmDbContext.Accounts.FindAsync(id);

            var mappedEntity = _mapper.Map<AccountsModel>(entity);

            return mappedEntity ?? new AccountsModel();
        }

        public ValueTask UpdateAsync(AccountsModel item)
        {
            throw new NotImplementedException();
        }
    }
}
