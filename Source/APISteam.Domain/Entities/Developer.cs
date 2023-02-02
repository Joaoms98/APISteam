using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APISteam.Domain.Entities
{
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public User UserId { get; set; }

        [Required]
        public string Document { get; set; }
        [Required]
        public string Account { get; set; }

        public User User { get; set; }
        public virtual List<Game> Game { get; set; }
    }
}