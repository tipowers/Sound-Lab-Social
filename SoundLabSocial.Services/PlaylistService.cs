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

        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity = new Playlist()
            {
                Id = _userId,
                PlaylistName = model.PlaylistName,
                PersonalAudioId = model.PersonalAudioId,
                CreatedUTC = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlaylistListItem> GetPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists
                    .Where(e => e.Id == _userId)
                    .Select(
                    e => new PlaylistListItem
                    {
                        PlaylistId = e.PlaylistId,
                        PlaylistName = e.PlaylistName,
                        PersonalAudioId = e.PersonalAudioId,
                        CreatedUTC = e.CreatedUTC
                    }
                );
                return query.ToArray();
            }
        }

        public PlaylistDetail GetPlaylistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists
                    .Single(e => e.PlaylistId == id && e.Id == _userId);
                return new PlaylistDetail
                {
                    PlaylistId = entity.PlaylistId,
                    PlaylistName = entity.PlaylistName,
                    PersonalAudioId = entity.PersonalAudioId,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists
                    .Single(e => e.PlaylistId == model.PlaylistId && e.Id == _userId);
                entity.PlaylistName = model.PlaylistName;
                entity.PersonalAudioId = model.PersonalAudioId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists
                    .Single(e => e.PlaylistId == playlistId && e.Id == _userId);

                ctx.Playlists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
