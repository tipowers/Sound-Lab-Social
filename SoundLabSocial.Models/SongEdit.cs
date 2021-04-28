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
        public int SongId { get; set; }

        public string SongName { get; set; }

        public string SongArtist { get; set; }

        public string SongAlbum { get; set; }

        public string ReleaseYear { get; set; }
    }
}
