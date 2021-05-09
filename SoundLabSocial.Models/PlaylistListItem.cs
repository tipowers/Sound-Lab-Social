using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PlaylistListItem
    {
        [Display(Name = "Playlist Id")]
        public int PlaylistId { get; set; }

        [Display(Name = "Playlist Name")]
        public string PlaylistName { get; set; }

        [Display(Name = "Personal Audio Id")]
        public int? PersonalAudioId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
