using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class WorkerTrackerModel
    {
        public Guid WorkerId { get; set; }

        [Required]
        [Display(Name ="KGs Picked")]
        public decimal KiloGramsPicked { get; set; }
    }
}
