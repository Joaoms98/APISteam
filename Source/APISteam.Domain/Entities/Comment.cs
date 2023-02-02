

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Game")]
        public Game GameId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The description can be a maximum of 500 characters")]
        public string Description { get; set; }
        [Required]
        public bool Review { get; set; }
        
        public Game Game { get; set; }
    }
}