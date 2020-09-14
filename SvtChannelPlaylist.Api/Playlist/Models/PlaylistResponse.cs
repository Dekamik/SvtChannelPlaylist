using SvtChannelPlaylist.Api.Common;
using System.Collections.Generic;

namespace SvtChannelPlaylist.Api.Playlist.Models
{
    public class PlaylistResponse : ApiResponse
    {
        public IEnumerable<RecordLabel> RecordLabels { get; set; }
    }
}
