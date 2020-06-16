using System;
using System.Collections.Generic;

namespace Kolokwium2.Models
{
    public partial class Track
    {
        public Track()
        {
            MusicianTrack = new HashSet<MusicianTrack>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double Duration { get; set; }
        public int AlbumIdAlbum { get; set; }

        public virtual Album AlbumIdAlbumNavigation { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTrack { get; set; }
    }
}
