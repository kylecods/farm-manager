using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class WorkerModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Worker Name")]
        public string? WorkerName { get; set; } = default!;

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\254[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        [MaxLength(13)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; } = default!;

        public DateTime CreatedDate { get; set; }
    }
}
