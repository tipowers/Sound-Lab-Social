using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Models
{
    public class PersonalAudioListItem
    {
        [Display(Name = "Personal Audio Id")]
        public int AudioId { get; set; }

        [Display(Name = "Personal Audio Name")]
        public string AudioName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
