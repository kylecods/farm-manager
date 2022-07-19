namespace Entities
{
    public class FactoryCollection : Entity
    {
        public Guid? FactoryId { get; set; }

        public virtual Factory? Factory { get; set; }

        public decimal Weight { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaidDate { get; set; }
    }
}
