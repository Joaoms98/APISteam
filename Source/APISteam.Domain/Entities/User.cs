using System.ComponentModel.DataAnnotations;


namespace APISteam.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "The nickname can be a maximum of 50 characters")]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }             
        [StringLength(100, ErrorMessage = "The real name can be a maximum of 100 characters")]
        public string RealName { get; set; }
        [StringLength(250, ErrorMessage = "The resume can be a maximum of 250 characters")]
        public string Resume { get; set; }
        [StringLength(250, ErrorMessage = "The country can be a maximum of 250 characters")]
         public string Country { get; set; }
        [StringLength(250, ErrorMessage = "The state can be a maximum of 250 characters")]
        public string State { get; set; }
        [StringLength(250, ErrorMessage = "The city can be a maximum of 250 characters")]
        public string City { get; set; }


        public virtual Developer Developer { get; set; }
        public virtual Publisher  Publisher { get; set; }
        public virtual List<Library> Library { get; set; }

        


    }
}