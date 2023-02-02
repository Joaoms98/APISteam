using System.ComponentModel.DataAnnotations;
using APISteam.Core.Entities;

namespace APISteam.Domain.Entities
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Type { get; set; }

        public virtual GameGenre GameGenre { get; set; }
    }
}