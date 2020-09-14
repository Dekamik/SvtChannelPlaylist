using System.Collections.Generic;

namespace SvtChannelPlaylist.Api.Playlist.Models
{
    public class PlaylistResponse
    {
        public IEnumerable<RecordLabel> RecordLabels { get; set; }
    }
}
