using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PersonalAudioDetail
    {
        [Display(Name = "Personal Audio Id")]
        public int PersonalAudioId { get; set; }

        [Display(Name = "Personal Audio Name")]
        public string AudioName { get; set; }

        [Display(Name = "Personal Audio Message")]
        public string AudioMessage { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

        [Display(Name = "Playlist Id")]
        public int? PlaylistId { get; set; }
    }
}
