﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SvtChannelPlaylist.Dispatcher.Common
{
    public abstract class ApiDispatcher : IApiDispatcher
    {
        private readonly HttpClient _httpClient;

        internal Uri Url { 
            set
            {
                _httpClient.BaseAddress = value;
            }
        }

        public ApiDispatcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

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
