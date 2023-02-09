using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual List<Game> Game { get; set; }
    }
}