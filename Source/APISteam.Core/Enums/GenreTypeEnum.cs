using System.ComponentModel.DataAnnotations;

namespace APISteam.Core.Enums
{
    public enum GenreTypeEnum
    {
        [Display(Name = "Action")]
        action = 0, 
        [Display(Name = "RPG")]
        rpg = 1,
        [Display(Name = "Adult")]
        adult = 2,
        [Display(Name = "FPS")]
        fps = 3,
        [Display(Name = "Sandbox")]
        sandbox = 4,
        [Display(Name = "Simulator")]
        simulator = 5,
        [Display(Name = "Indie")]
        indie = 6,
        [Display(Name = "Adventure")]
        adventure = 7,
        [Display(Name = "Horror")]
        horror = 8


    }
}