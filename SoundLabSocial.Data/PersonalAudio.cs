using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Data
{
    public class PersonalAudio
    {
        [Key]
        public int PersonalAudioId { get; set; }

        [Required] 
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string AudioName { get; set; }

        public string AudioMessage { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }

        //public virtual ICollection<Playlist> Playlists { get; set; }
        [ForeignKey(nameof(Playlist))]
        public int? PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
