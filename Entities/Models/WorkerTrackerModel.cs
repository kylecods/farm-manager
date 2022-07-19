using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entities.Models
{
    public class WorkerTrackerModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Worker Name")]
        public Guid WorkerId { get; set; }

        [Display(Name = "Activity Done")]
        public Activities Activity { get; set; }

        [Display(Name = "KGs Picked")]
        public decimal KiloGramsPicked { get; set; }

        public string ActivityDesc => Enum.GetName(typeof(Activities), Activity);

        [Display(Name = "Amount Paid(per KG)")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Date work done")]
        public DateTime PickedDate { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
