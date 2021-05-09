using SoundLabSocial.Data;
using SoundLabSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Services
{
    public class SongService
    {
        private readonly string _userId;

        public SongService(string userId)
        {
            _userId = userId;
        }

        public bool CreateSong(SongCreate model)
        {
            var entity = new Song()
            {
                Id = _userId,
                SongName = model.SongName,
                SongArtist = model.SongArtist,
                SongAlbum = model.SongAlbum,
                ReleaseYear = model.ReleaseYear,
                CreatedUTC = DateTimeOffset.Now//,
                //Playlists = model.PlaylistId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Songs
                    .Where(e => e.Id == _userId)
                    .Select(
                    e => new SongListItem
                    {
                        SongId = e.SongId,
                        SongName = e.SongName,
                        SongArtist = e.SongArtist,
                        SongAlbum = e.SongAlbum,
                        ReleaseYear = e.ReleaseYear,
                        CreatedUTC = e.CreatedUTC
                    }
                );
                return query.ToArray();
            }
        }

        public SongDetail GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs
                    .Single(e => e.SongId == id && e.Id == _userId);
                return new SongDetail
                {
                    SongId = entity.SongId,
                    SongName = entity.SongName,
                    SongArtist = entity.SongArtist,
                    SongAlbum = entity.SongAlbum,
                    ReleaseYear = entity.ReleaseYear,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs
                    .Single(e => e.SongId == model.SongId && e.Id == _userId);
                entity.SongName = model.SongName;
                entity.SongArtist = model.SongArtist;
                entity.SongAlbum = model.SongAlbum;
                entity.ReleaseYear = model.ReleaseYear;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs
                    .Single(e => e.SongId == songId && e.Id == _userId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
