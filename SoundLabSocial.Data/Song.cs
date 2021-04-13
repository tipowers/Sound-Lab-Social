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

        [Required]
        //Foreign Key here ....
        //Also GUID ??? 
        public int UserId { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string SongArtist { get; set; }

        [Required]
        public string SongAlbum { get; set; }

        public DateTime ReleaseYear { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }

}
