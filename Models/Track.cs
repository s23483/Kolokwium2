using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(100)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        [ForeignKey("Album")]
        public int? IdMusicAlbum { get; set; }
    }
}