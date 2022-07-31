using AutoMapper;
using Entities;
using Entities.Models;
namespace Repositories.Mappers
{
    public class RegisterMapper :Profile
    {
        public RegisterMapper()
        {
            CreateMap<Register, RegisterModel>();
        }

        public static Register CreateRegister(RegisterModel item)
        {
            var register = new Register();

            register.SetNewId();

            register.AccountsId = item.AccountsId;

            register.Amount = item.Amount;

            register.Date = item.Date;

            register.CreatedDate = DateTime.Now;

            return register;

        }
    }
}
