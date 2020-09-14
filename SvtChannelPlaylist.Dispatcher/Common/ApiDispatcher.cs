using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    public abstract class ApiDispatcher<TResponse>
    {
        private readonly HttpClient _httpClient;
        internal string Url;

        public ApiDispatcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<TResponse> Get(IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new ArgumentNullException($"{nameof(Url)} in class derived from {nameof(ApiDispatcher<TResponse>)} must be set");
            }

            TResponse responseObject = default;
            string parametersString = parameters.Count() != 0 ? ParseParameters(parameters) : "";
            var uri = new Uri($"{Url}{parametersString}");

            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                responseObject = await response.Content.ReadAsAsync<TResponse>();
            }
            // TODO: Handle non-success status code

            return responseObject;
        }

        private string ParseParameters(IDictionary<string, string> parameters) => "?" + parameters.Select(p => $"{p.Key}={p.Value}");
    }
}
