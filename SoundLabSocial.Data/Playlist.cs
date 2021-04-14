using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Data
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        //GUID ??? 
        public int UserId { get; set; }
        //Do I need a virtual list of users here?

        //SongId not required because playlist is initially empty.
        //Actually it's not empty because it will be auto-filled with my songs
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(PersonalAudio))]
        public int PersonalAudioId { get; set; }
        // Do I need a list here if only one audio file is tied to the playlist?
        public virtual PersonalAudio PersonalAudio { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
