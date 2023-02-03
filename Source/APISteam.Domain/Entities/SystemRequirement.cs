using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISteam.Domain.Entities
{
    public class SystemRequirement
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public int MinMax { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Memory { get; set; }

        [Required]
        public string Graphics { get; set; }

        [Required]
        public string DirectX { get; set; }

        [Required]
        public string Storage { get; set; }

        public string AdditionalInfo { get; set; }
    }
}