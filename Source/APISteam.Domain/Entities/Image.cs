using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [ForeignKey("Game")]
        public Guid GameId {get; set; } 
           
        [Required]
        public string Link {get; set; }

        public Game Game {get; set; }
    }
}