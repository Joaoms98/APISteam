using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Video")]
    public class Video
    {
        [Key]
        public Guid Id { get; set; }
        
        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public string Link { get; set; }
    }
}