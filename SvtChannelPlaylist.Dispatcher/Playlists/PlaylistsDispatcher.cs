using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.Playlists.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Playlists
{
    public class PlaylistsDispatcher : ApiDispatcher<SongList>, IPlaylistsDispatcher
    {
        public PlaylistsDispatcher(HttpClient httpClient) : base(httpClient)
        {
            Url = new Uri("http://api.sr.se/api/v2/playlists/");
        }

        public async Task<SongList> GetPlaylistByChannelId(int id, DateTime? start, DateTime? end, int? size)
        {
            var parameters = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };

            if (start.HasValue)
                parameters.Add("startdatetime", start.Value.ToString("yyyy-MM-dd"));
            if (end.HasValue)
                parameters.Add("enddatetime", end.Value.ToString("yyyy-MM-dd"));
            if (size.HasValue)
                parameters.Add("size", size.ToString());

            return await GetAsync("getplaylistbychannelid", parameters);
        }
    }
}
