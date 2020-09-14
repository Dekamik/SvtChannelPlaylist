using System;
using System.Collections.Generic;
using System.Text;

namespace SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models
{
    public class Song
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Artist { get; set; }

        public string Albumname { get; set; }

        public string Recordlabel { get; set; }

        public DateTime Starttimeutc { get; set; }

        public DateTime Stoptimeutc { get; set; }
    }
}
