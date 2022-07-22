using System.ComponentModel.DataAnnotations;

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
        Pruning,
        [Display(Name = "Other")]
        Other
    }

    public enum AccountType
    {
        [Display(Name = "Expenses")]
        Expenses = 1,

        [Display(Name = "Income")]
        Income
    }
}
