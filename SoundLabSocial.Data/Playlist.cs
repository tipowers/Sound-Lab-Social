﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string PlaylistName { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }       
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Song> Song { get; set; } = new List<Song>();

        [ForeignKey(nameof(PersonalAudio))]
        public int? PersonalAudioId { get; set; }
        public virtual PersonalAudio PersonalAudio { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
