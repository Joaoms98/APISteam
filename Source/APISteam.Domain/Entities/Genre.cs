using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual List<GameGenre> GameGenre { get; set; }
    }
}