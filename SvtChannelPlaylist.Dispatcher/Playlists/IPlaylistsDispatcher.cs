using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.Playlists.Models;
using System;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Playlists
{
    public interface IPlaylistsDispatcher : IApiDispatcher
    {
        /// <summary>
        /// Gets a channel's playlist
        /// </summary>
        /// <param name="id">Channel ID</param>
        /// <param name="start">Date from</param>
        /// <param name="end">Date to</param>
        /// <param name="size">Max amount of songs to fetch</param>
        /// <returns>A <see cref="SongList"/> for specified channel</returns>
        Task<SongList> GetPlaylistByChannelId(int id, DateTime? start, DateTime? end, int? size);
    }
}
