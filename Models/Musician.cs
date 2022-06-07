using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models
{
    public class Musician
    {
        [Key]
        public int IdMusician { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Nickname { get; set; }
    }
}