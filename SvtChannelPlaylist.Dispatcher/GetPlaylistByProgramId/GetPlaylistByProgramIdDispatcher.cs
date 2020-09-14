using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models;
using System.Net.Http;

namespace SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId
{
    public class GetPlaylistByProgramIdDispatcher : ApiDispatcher<SongList>
    {
        public GetPlaylistByProgramIdDispatcher(HttpClient httpClient) : base(httpClient)
        {
            Url = "http://api.sr.se/api/v2/playlists/getplaylistbychannelid";
        }
    }
}
