using Entities.Models;

namespace Entities
{
    public class Accounts : Entity
    {
        public Activities Activity { get; set; }

        public AccountType AccountType { get; set; }

        public decimal StartAmount { get; set; }

    }
}
