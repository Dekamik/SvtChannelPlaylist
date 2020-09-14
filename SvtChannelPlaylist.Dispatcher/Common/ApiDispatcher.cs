using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    /// <summary>
    /// A dispatcher for calling external API endpoints.
    /// </summary>
    public abstract class ApiDispatcher : IApiDispatcher
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Sets the <see cref="HttpClient.BaseAddress"/> for the <see cref="ApiDispatcher"/>'s <see cref="HttpClient"/>
        /// </summary>
        internal Uri Url { 
            set
            {
                _httpClient.BaseAddress = value;
            }
        }

        /// <summary>
        /// Creates the <see cref="ApiDispatcher"/>. Url must be set seperately.
        /// </summary>
        /// <param name="httpClient"></param>
        public ApiDispatcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<TResponse> GetAsync<TResponse>(string route, IDictionary<string, string> parameters)
        {
            if (_httpClient.BaseAddress == null)
            {
                throw new ArgumentNullException($"{nameof(Url)} in class derived from {nameof(ApiDispatcher)} must be set");
            }

            TResponse responseObject = default;
            string parametersString = ParseParameters(parameters);

            HttpResponseMessage response = await _httpClient.GetAsync($"{route}?{parametersString}");

            if (response.IsSuccessStatusCode)
            {
                responseObject = await response.Content.ReadAsAsync<TResponse>();
            }
            // TODO: Handle non-success status code

            return responseObject;
        }

        private string ParseParameters(IDictionary<string, string> parameters) => "format=json" + string.Join("", parameters.Select(p => $"&{p.Key}={p.Value}"));
    }
}
