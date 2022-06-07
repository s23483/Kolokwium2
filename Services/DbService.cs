using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Kolokwium2.Models;
using Kolokwium2.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<SomeAlbum> GetAlbum(int id)
        {
            
                var album =  await _dbContext.Albums.FindAsync(id);
                if (album == null)
                {
                    throw new FileNotFoundException();
                }
                IEnumerable<Track> tracks =  await _dbContext.Tracks
                    .Where(e => e.IdMusicAlbum == id)
                    .ToListAsync();
                return new SomeAlbum
                {
                    AlbumName = album.AlbumName,
                    Duration = album.Duration,
                    IdAlbum = album.IdAlbum,
                    IdMusicLabel = album.IdMusicLabel,
                    Tracks = tracks
                };
        }

        public async Task<int> DeleteMusician(int id)
        {
            try
            {
                var musician = new Musician() {IdMusician = id};
                 var entity = _dbContext.Attach(musician);
                if (entity.Entity.Nickname == null)
                {
                    return 1;
                }
                
                if (await _dbContext.MusicianTracks.Include(e => e.IdTrack).Where(e => 
                        (e.IdMusician == id && _dbContext.Tracks.Find(e.IdTrack).IdMusicAlbum!=null))
                    .AnyAsync())
                    return 2;
                _dbContext.Remove(musician);
                await _dbContext.SaveChangesAsync();
                return 0;
            }
            catch (SqlException)
            {
                return 3;
            }
        }
    }
}