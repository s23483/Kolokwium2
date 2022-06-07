using System.Collections.Generic;

namespace Kolokwium2.Models.DTO
{
    public class SomeAlbum
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public float Duration { get; set; }
        public int IdMusicLabel { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}