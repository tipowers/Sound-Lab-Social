using SoundLabSocial.Data;
using SoundLabSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Services
{
    public class PlaylistService
    {
        private readonly string _userId;

        public PlaylistService(string userId)
        {
            _userId = userId;
        }

        public bool CreateSong(PlaylistCreate model)
        {
            var entity = new Playlist()
            {
                Id = _userId,
                PlaylistName = model.PlaylistName,
                CreatedUTC = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /*public IEnumerable<PlaylistListItem> GetPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists
                    .Where(e => e.Id == _userId)
                    .Select(
                    e => new Playlist
                    {
                        PlaylistName = e.PlaylistName
                    }
                );
                return query.ToArray();
            }
        }*/
    }
}
