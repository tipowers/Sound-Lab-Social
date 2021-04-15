using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class SongListItem
    {
        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Artist")]
        public string SongArtist { get; set; }

        [Display(Name = "Album")]
        public string SongAlbum { get; set; }

        [Display(Name = "Release Year")]
        public DateTime ReleaseYear { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUTC { get; set; }

    }
}
