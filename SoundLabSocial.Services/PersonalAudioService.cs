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

        public bool CreateSong(PersonalAudioCreate model)
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
                       AudioName = e.AudioName
                    }
                );
                return query.ToArray();
            }
        }
    }
}
