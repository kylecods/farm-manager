using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class FactoryModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Factory Name")]
        public string FactoryName { get; set; }

        [Required]
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
