using AutoMapper;
using Entities;
using Entities.Models;
using Repositories.Mappers;

namespace Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly FarmDbContext _farmDbContext;

        private readonly IAccountsRepository _accountsRepository;

        private readonly IMapper _mapper;

        public RegisterRepository(FarmDbContext farmDbContext, IMapper mapper,IAccountsRepository accountsRepository)
        {
            _farmDbContext = farmDbContext ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();

            _accountsRepository = accountsRepository ?? throw new ArgumentNullException();
        }

        public async virtual ValueTask AddAsync(RegisterModel item)
        {
            var register = RegisterMapper.CreateRegister(item);

            await _farmDbContext.AddAsync(register!);

            await _farmDbContext.SaveChangesAsync();
        }

        public virtual ValueTask DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async virtual ValueTask<IEnumerable<RegisterModel>> GetAllAsync()
        {
            var result = _farmDbContext.Registers;

            var mappedResult = _mapper.Map<IEnumerable<Register>, IEnumerable<RegisterModel>>(result);

            return await ValueTask.FromResult(mappedResult);
        }

        public async virtual ValueTask<IEnumerable<RegisterModel>> GetAllByAccountIdAsync(Guid accountId)
        {
            var account = await _accountsRepository.GetByIdAsync(accountId);

            var result = _farmDbContext.Registers.Where(x => x.AccountsId == accountId).Select(reg => new RegisterModel()
            {
                Id = reg.Id,
                AccountsId = account.Id,
                AccountType = account.AccountType,
                Activity = account.Activity,
                Amount = account.StartAmount + reg.Amount,
                Date = reg.Date,
                CreatedDate = reg.CreatedDate
            }).AsEnumerable();
 

            return await ValueTask.FromResult(result);
        }

        public async virtual ValueTask<RegisterModel> GetByIdAsync(Guid id)
        {
            var entity = await _farmDbContext.Registers.FindAsync(id);

            var mappedEntity = _mapper.Map<RegisterModel>(entity);

            return mappedEntity ?? new RegisterModel();
        }

        public virtual ValueTask UpdateAsync(RegisterModel item)
        {
            throw new NotImplementedException();
        }
    }
}
