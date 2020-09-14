using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    public interface IApiDispatcher
    {
        /// <summary>
        /// Fetches a resource from the specified <paramref name="route"/> with the specified <paramref name="parameters"/> on the endpoint.
        /// </summary>
        /// <typeparam name="TResponse">API endpoint response type</typeparam>
        /// <param name="route">Route to external API endpoint</param>
        /// <param name="parameters"></param>
        /// <returns>The response parsed as <typeparamref name="TResponse"/></returns>
        Task<TResponse> GetAsync<TResponse>(string route, IDictionary<string, string> parameters);
    }
}
