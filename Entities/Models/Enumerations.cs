using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Entities.Models
{
    public enum Activities
    {
        [Display(Name = "Plucking")]
        Plucking = 1,
        [Display(Name = "Weeding")]
        Weeding,
        [Display(Name = "Top Dressing")]
        TopDressing,
        [Display(Name = "Pruning")]
        Pruning
    }
}
