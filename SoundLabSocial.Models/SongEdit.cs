using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class SongEdit
    {
        [Display(Name = "Song Id")]
        public int SongId { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Song Artist")]
        public string SongArtist { get; set; }

        [Display(Name = "Song Album")]
        public string SongAlbum { get; set; }

        [Display(Name = "Release Year")]
        public string ReleaseYear { get; set; }

        [Display(Name = "Playlist Id")]
        public int? PlaylistId { get; set; }
    }
}
