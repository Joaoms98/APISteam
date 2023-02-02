using System.ComponentModel.DataAnnotations;


namespace APISteam.Domain.Entities
{
    public class Publisher
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual List<Game> Game { get; set; }

    }
}