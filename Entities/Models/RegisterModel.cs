
namespace Entities.Models
{
    public class RegisterModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public AccountType AccountType { get; set; }

        public string AccountDesc => Enum.GetName(typeof(AccountType), AccountType);

        public Activities Activity { get; set; }

        public string ActivityDesc => Enum.GetName(typeof(Activities), Activity);

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
