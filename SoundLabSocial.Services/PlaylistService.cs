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
                    Songs = entity.Song.Select(e => new Models.SongListItem()
                    {
                        SongName = e.SongName,
                        SongArtist = e.SongArtist,
                        SongAlbum = e.SongAlbum,
                        ReleaseYear = e.ReleaseYear,
                        CreatedUTC = e.CreatedUTC,
                        SongId = e.SongId
                    }).ToList(),
                    PersonalAudios = entity.PersonalRecording.Select(e => new Models.PersonalAudioListItem()
                    {
                        AudioName = e.AudioName,
                        AudioMessage = e.AudioMessage,
                        CreatedUTC = e.CreatedUTC
                    }).ToList(),
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
