using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class WorkerTrackerModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Worker Name")]
        public Guid WorkerId { get; set; }

        [Required]
        [Display(Name ="KGs Picked")]
        public decimal KiloGramsPicked { get; set; }

        public byte Activity { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PickedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<SelectListItem> Workers { get; set; }
    }
}
