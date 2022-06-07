using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician_Track> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician>(p =>
            {
                p.HasData(
                    new Musician{ FirstName = "Marian", Nickname = "maro",IdMusician = 1,LastName = "Prucki"}
                );
            });
            modelBuilder.Entity<Track>(p =>
            {
                p.HasData(
                    new Track{Duration = 1.2f , IdTrack = 1, IdMusicAlbum = 1,TrackName = "dens"},
                new Track{Duration = 1.3f , IdTrack = 2,TrackName = "najt"}
                );
            });
            modelBuilder.Entity<Musician_Track>(p =>
            {
                p.HasKey(e => e.IdMusician);
                p.HasKey(e => e.IdTrack);
                p.HasData(
                    new Musician_Track{IdMusician = 1,IdTrack = 1},
                    new Musician_Track{IdMusician = 1,IdTrack = 2}
                );
            });
            modelBuilder.Entity<Album>(p =>
            {
                p.HasData(
                    new Album{IdAlbum = 1,AlbumName = "tekno",IdMusicLabel = 1,Duration = 1.2f}
                );
            });
            modelBuilder.Entity<MusicLabel>(p =>
            {
                p.HasData(
                    new MusicLabel{ IdMusicLabel = 1,Name = "gengsta"}
                );
            });
            
        }
    }
}