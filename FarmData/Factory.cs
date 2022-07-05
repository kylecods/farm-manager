namespace DomainLayer
{
    public class FactoryModel
    {
        public Guid Id { get; set; }

        public decimal Weight { get; set; }

        public string FactoryName { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}