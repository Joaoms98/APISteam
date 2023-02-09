using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("GameGenre")]
    public class GameGenre
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}