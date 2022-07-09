using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class FactoryModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Display(Name = "Factory Name")]
        public string FactoryName { get; set; }

        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Paid Date")]
        public DateTime PaidDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}