using Entities.Models;

namespace Entities
{
    public class WorkerTracker : Entity
    {
        public Guid? WorkerId { get; set; }

        public virtual Worker? Worker { get; set; }

        public decimal KiloGramsPicked { get; set; }

        public Activities Activity { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PickedDate { get; set; }
    }
}
