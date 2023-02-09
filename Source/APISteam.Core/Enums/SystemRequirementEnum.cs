using System.ComponentModel.DataAnnotations;

namespace APISteam.Core.Enums
{
    public enum SystemRequirementEnum
    {
        [Display(Name = "Action")]
        Minimum = 1,
        
        [Display(Name = "Action")]
        Maximum = 2
    }
}