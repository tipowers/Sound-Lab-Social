using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PlaylistEdit
    {
        [Display(Name = "Playlist Id")]
        public int PlaylistId { get; set; }

        [Display(Name = "Playlist Name")]
        public string PlaylistName { get; set; }
    }
}
