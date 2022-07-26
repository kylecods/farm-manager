
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class AccountsModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Account")]
        public AccountType AccountType { get; set; }

        public string AccountDesc => Enum.GetName(typeof(AccountType), AccountType);

        [Display(Name = "Activity Done")]
        public Activities Activity { get; set; }

        public string ActivityDesc => Enum.GetName(typeof(Activities), Activity);

        [Display(Name ="Starting Amount")]
        public decimal StartAmount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
