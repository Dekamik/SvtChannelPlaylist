using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            PlaylistResponse model = CreateModel(list);

            return Ok(model);
        }

        private PlaylistResponse CreateModel(SongList list)
        {
            IEnumerable<string> recordLabels = list.Song
                .Select(s => s.Recordlabel)
                .Distinct();

            return new PlaylistResponse
            {
                RecordLabels = recordLabels
                    .OrderBy(r => r)
                    .Select(recordLabelName => new RecordLabel
                    {
                        Name = recordLabelName,
                        Artists = list.Song
                            .Where(s => s.Recordlabel == recordLabelName)
                            .OrderBy(s => s.Artist)
                            .GroupBy(s => s.Artist)
                            .Select(artistSongGroup => artistSongGroup.Key)
                    })
            };
        }
    }
}