using AutoMapper;
using Entities;
using Entities.Models;

namespace Repositories.Mappers
{
    public class AccountsMapper : Profile
    {
        public AccountsMapper()
        {
            CreateMap<Accounts, AccountsModel>();
        }

        public static Accounts CreateAccounts(AccountsModel item)
        {
            var accounts = new Accounts();

            accounts.SetNewId();

            accounts.Activity = item.Activities;

            accounts.AccountType = item.AccountType;

            accounts.StartAmount = item.StartAmount;

            accounts.CreatedDate = DateTime.Now;

            return accounts;
        }
    }
}
