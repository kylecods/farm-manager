using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class WorkerModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string WorkerName { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\254[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
    }
}
