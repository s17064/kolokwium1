﻿using System;
using System.Collections.Generic;

namespace Kolokwium2.Models
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int MusicLabelIdMusicLabel { get; set; }

        public virtual MusicLabel MusicLabelIdMusicLabelNavigation { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
