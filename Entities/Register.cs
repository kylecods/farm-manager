using Entities.Models;

namespace Entities
{
    public class Register : Entity
    {

        public Guid AccountId { get; set; }

        public virtual Accounts? Accounts { get; set; }

        public Activities Activity { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
