using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APISteam.Domain.Entities
{
    public class Library
    {
        [Key]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Game")]
        public Guid GameId { get; set; }

        [Required]
        public double GameHours { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}