using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvtChannelPlaylist.Api.Playlist.Models;
using SvtChannelPlaylist.Dispatcher.Playlists;
using SvtChannelPlaylist.Dispatcher.Playlists.Models;

namespace SvtChannelPlaylist.Api.Playlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistsDispatcher _playlistDispatcher;

        public PlaylistController(IPlaylistsDispatcher playlistDispatcher)
        {
            _playlistDispatcher = playlistDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylist()
        {
            SongList list = await _playlistDispatcher.GetPlaylistByChannelId(
                132, 
                DateTime.Parse("2020-09-10"), 
                DateTime.Parse("2020-09-13"), 
                100);

            return Ok(new PlaylistResponse());
        }

        private PlaylistResponse CreateModel(SongList list)
        {
            throw new NotImplementedException();
        }
    }
}