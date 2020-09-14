using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    public interface IApiDispatcher<TResponse>
    {
        Task<TResponse> GetAsync(string route, IDictionary<string, string> parameters);
    }
}
