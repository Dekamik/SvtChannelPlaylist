using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    public interface IApiDispatcher
    {
        Task<TResponse> GetAsync<TResponse>(string route, IDictionary<string, string> parameters);
    }
}
