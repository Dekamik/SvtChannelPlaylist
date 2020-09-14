using System;
using System.Collections.Generic;
using System.Text;

namespace SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models
{
    public class SongList
    {
        public string Copyright { get; set; }

        public IEnumerable<Song> Song { get; set; }
    }
}
