using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Game")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Developer")]
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }

        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
        [ForeignKey("Franchise")]
        public Guid FranchiseId { get; set; }
        public Franchise Franchise { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="the length of the field must be up to 100 characters long")]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(300, ErrorMessage ="the length of the field must be up to 300 characters long")]
        public string Description { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public int PredominantGenre { get; set; }

        #region prop navigate
        public virtual SystemRequirement SystemRequirement { get; set; }
        public virtual List<GameGenre> GameGenre { get; set; }
        public virtual List<Library> Library { get; set; }
        public virtual List<Image> Image { get; set; }
        public virtual List<Comment> Comment { get; set; }
        public virtual List<Video> Video { get; set; }
        #endregion
    }
}