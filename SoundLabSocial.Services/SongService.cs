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
                CreatedUTC = DateTimeOffset.Now
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
                        SongName = e.SongName,
                        SongArtist = e.SongArtist,
                        SongAlbum = e.SongAlbum,
                        ReleaseYear = e.ReleaseYear
                    }
                );
                return query.ToArray();
            }
        }
    }
}
