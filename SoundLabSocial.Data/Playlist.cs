using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //Foreign Key here ....
        //Revisit Simon's video
        //Also GUID ??? 
        public int UserId { get; set; }

        //Foreign key here ... [Key]
        //SongId not required because playlist is initially empty.
        //Actually it's not empty because it will be auto-filled with my songs
        public int SongId { get; set; }

        //Foreign key here ... [Key]
        public int AudioId { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
