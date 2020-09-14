using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvtChannelPlaylist.Api.Playlist.Models;
using SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId;
using SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models;

namespace SvtChannelPlaylist.Api.Playlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IGetPlaylistByChannelIdDispatcher _playlistDispatcher;

        public PlaylistController(IGetPlaylistByChannelIdDispatcher playlistDispatcher)
        {
            _playlistDispatcher = playlistDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylist()
        {
            SongList list = await _playlistDispatcher.GetAsync(new Dictionary<string, string>
            {
                { "id", "132" },
                { "startdatetime", "2020-09-10" },
                { "enddatetime", "2020-09-13" },
                { "size", "100" }
            });

            return Ok(new PlaylistResponse());
        }
    }
}