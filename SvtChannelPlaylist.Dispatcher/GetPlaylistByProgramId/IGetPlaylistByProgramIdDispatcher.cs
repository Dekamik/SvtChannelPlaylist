using SvtChannelPlaylist.Dispatcher.Common;
using SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvtChannelPlaylist.Dispatcher.GetPlaylistByProgramId
{
    public interface IGetPlaylistByChannelIdDispatcher : IApiDispatcher<SongList>
    {
    }
}
