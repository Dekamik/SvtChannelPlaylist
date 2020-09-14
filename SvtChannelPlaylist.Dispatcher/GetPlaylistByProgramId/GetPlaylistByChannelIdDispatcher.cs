using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models;
using System;
using System.Net.Http;

namespace SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId
{
    public class GetPlaylistByChannelIdDispatcher : ApiDispatcher<SongList>, IGetPlaylistByChannelIdDispatcher
    {
        public GetPlaylistByChannelIdDispatcher(HttpClient httpClient) : base(httpClient)
        {
            Url = new Uri("http://api.sr.se/api/v2/playlists/getplaylistbychannelid");
        }
    }
}
