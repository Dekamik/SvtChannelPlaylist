using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SvtChannelPlaylist.Api.Playlist.Models;

namespace SvtChannelPlaylist.Api.Playlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        [HttpGet]
        public async Task<PlaylistResponse> GetPlaylist()
        {
            throw new NotImplementedException();
        }
    }
}