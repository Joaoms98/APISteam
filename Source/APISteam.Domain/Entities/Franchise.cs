using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    [Table("Franchise")]
    public class Franchise
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The franchise can be a maximum of 255 characters")]
        public string Name { get; set; }
        
        [Required]
        public string Image { get; set; }
      
        public virtual List<Game> Game { get; set; }
    }
}