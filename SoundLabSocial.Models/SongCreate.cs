using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class SongCreate
    {
        [Required]
        [Display(Name = "Song Name")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string SongName { get; set; }

        [Required]
        [Display(Name = "Artist")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string SongArtist { get; set; }

        [Display(Name = "Album")]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string SongAlbum { get; set; }

        [Display(Name = "Release Year")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(4, ErrorMessage = "There are too many characters in this field.")]
        public string ReleaseYear { get; set; }
    }
}
