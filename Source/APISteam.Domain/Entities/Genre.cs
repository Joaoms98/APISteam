using System.ComponentModel.DataAnnotations;

namespace APISteam.Domain.Entities
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Type { get; set; }

        public virtual GameGenre GameGenre { get; set; }
    }
}