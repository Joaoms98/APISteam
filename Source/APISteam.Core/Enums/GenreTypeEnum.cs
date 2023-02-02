using System.ComponentModel.DataAnnotations;

namespace APISteam.Core.Enums
{
    public enum GenreTypeEnum
    {
        [Display(Name = "Action")]
        Action = 0, 
        [Display(Name = "RPG")]
        RPG = 1,
        [Display(Name = "Adult")]
        Adult = 2,
        [Display(Name = "FPS")]
        FPS = 3,
        [Display(Name = "Sandbox")]
        Sandbox = 4,
        [Display(Name = "Simulator")]
        Simulator = 5,
        [Display(Name = "Indie")]
        Indie = 6,
        [Display(Name = "Adventure")]
        Adventure = 7,
        [Display(Name = "Horror")]
        Horror = 8


    }
}