using System.Collections.Generic;

namespace SvtChannelPlaylist.Api.Playlist.Models
{
    public class RecordLabel
    {
        public string Name { get; set; }

        public IEnumerable<Artist> Artists { get; set; }
    }
}
