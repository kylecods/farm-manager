using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class FactoryModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Factory Name")]
        public string FactoryName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^(?!0+$)(\\+\\254[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
