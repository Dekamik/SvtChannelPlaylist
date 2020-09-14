using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.Playlists.Models;
using System;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Playlists
{
    public interface IPlaylistsDispatcher : IApiDispatcher<SongList>
    {
        Task<SongList> GetPlaylistByChannelId(int id, DateTime? start, DateTime? end, int? size);
    }
}
