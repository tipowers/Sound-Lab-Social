using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        //[Required] ... is a UserId required for a song to exist?
        // I would say at this point yes, since I have to manually add songs
        // But once using Spotify API this would no longer be necessary?
        // Follow-up on this line of questioning and ensure to migrate tables!!!
        //Foreign Key here ....
        //Revisit Simon's video
        //Also GUID ??? 
        public int UserId { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string SongArtist { get; set; }

        public string SongAlbum { get; set; }

        public DateTime ReleaseYear { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }

}
