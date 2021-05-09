using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PersonalAudioCreate
    {
        [Required]
        [Display(Name = "Personal Audio Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string AudioName { get; set; }

        [Display(Name = "Personal Audio Message")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string AudioMessage { get; set; }

        [Display(Name = "Playlist Id")]
        public int? PlaylistId { get; set; }
    }
}
