using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class FactoryCollectionModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Factory Name")]
        public Guid FactoryId { get; set; }

        public string FactoryName { get; set; }

        [Display(Name = "Weight")]
        [Required]
        public decimal Weight { get; set; }

        [Display(Name="Amount Paid")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Date Paid")]
        public DateTime PaidDate { get; set; }

        public List<SelectListItem> Factories { get; set; }
    }
}
