using System;
using System.Collections.Generic;
using System.Text;

namespace SvtChannelPlaylist.Dispatcher.Playlists.Models
{
    public class SongList
    {
        public string Copyright { get; set; }

        public IEnumerable<Song> Song { get; set; }
    }
}
