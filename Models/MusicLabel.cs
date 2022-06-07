using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models
{
    public class MusicLabel
    {
        [Key]
        public int IdMusicLabel { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}