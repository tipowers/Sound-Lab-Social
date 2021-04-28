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
                CreatedUTC = DateTimeOffset.Now
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
                       AudioName = e.AudioName,
                       CreatedUTC = e.CreatedUTC
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
                    .Single(e => e.AudioId == id && e.Id == _userId);
                return new PersonalAudioDetail
                {
                    AudioId = entity.AudioId,
                    AudioName = entity.AudioName,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdatePersonalAudio(PersonalAudioEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalAudios
                    .Single(e => e.AudioId == model.AudioId && e.Id == _userId);
                entity.AudioName = model.AudioName;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
