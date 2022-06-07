using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        [Required]
        [MaxLength(100)]
        public string AlbumName { get; set; }
        [Required]
        public float Duration { get; set; }
        [ForeignKey("MusicLabel")]
        public int IdMusicLabel { get; set; }
    }
}