using SoundLabSocial.Data;
using SoundLabSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Services
{
    public class PersonalAudioService
    {
        private readonly string _userId;

        public PersonalAudioService(string userId)
        {
            _userId = userId;
        }

        public bool CreatePersonalAudio(PersonalAudioCreate model)
        {
            var entity = new PersonalAudio()
            {
                Id = _userId,
                AudioName = model.AudioName,
                AudioMessage = model.AudioMessage,
                CreatedUTC = DateTimeOffset.Now,
                PlaylistId = model.PlaylistId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PersonalAudios.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonalAudioListItem> GetPersonalAudios()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PersonalAudios
                    .Where(e => e.Id == _userId)
                    .Select(
                    e => new PersonalAudioListItem
                    {
                       PersonalAudioId = e.PersonalAudioId,
                       AudioName = e.AudioName,
                       CreatedUTC = e.CreatedUTC,
                       PlaylistId = e.PlaylistId
                    }
                );
                return query.ToArray();
            }
        }

        public PersonalAudioDetail GetPersonalAudioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalAudios
                    .Single(e => e.PersonalAudioId == id && e.Id == _userId);
                return new PersonalAudioDetail
                {
                    PersonalAudioId = entity.PersonalAudioId,
                    AudioName = entity.AudioName,
                    AudioMessage = entity.AudioMessage,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC,
                    PlaylistId = entity.PlaylistId
                };
            }
        }

        public bool UpdatePersonalAudio(PersonalAudioEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalAudios
                    .Single(e => e.PersonalAudioId == model.PersonalAudioId && e.Id == _userId);
                entity.AudioName = model.AudioName;
                entity.AudioMessage = model.AudioMessage;
                entity.PlaylistId = model.PlaylistId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePersonalAudio(int audioId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalAudios
                    .Single(e => e.PersonalAudioId == audioId && e.Id == _userId);

                ctx.PersonalAudios.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
