﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string AudioName { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}