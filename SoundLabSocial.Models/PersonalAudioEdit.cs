using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PersonalAudioEdit
    {
        [Display(Name = "Audio Id")]
        public int AudioId { get; set; }

        [Display(Name = "Audio Name")]
        public string AudioName { get; set; }
    }
}
