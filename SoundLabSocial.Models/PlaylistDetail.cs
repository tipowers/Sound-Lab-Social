using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PlaylistDetail
    {
        [Display(Name = "Playlist Id")]
        public int PlaylistId { get; set; }

        [Display(Name = "Playlist Name")]
        public string PlaylistName { get; set; }

        public virtual ICollection<SongListItem> Songs { get; set; } = new List<SongListItem>();

        public virtual ICollection<PersonalAudioListItem> PersonalAudios { get; set; } = new List<PersonalAudioListItem>();

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
