using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLabSocial.Data
{
    public class PersonalAudio
    {
        [Key]
        public int AudioId { get; set; }

        [Required]
        //Foreign Key here ....
        //Revisit Simon's video
        //Also GUID ??? 
        public int UserId { get; set; }

        [Required]
        public string AudioName { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
