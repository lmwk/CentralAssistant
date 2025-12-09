using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace OpenMeteoWrapper
{
    public abstract class HttpRequest
    {
        protected static HttpClient _httpClient = new HttpClient();

        public List<object> PathParams { get; } = new List<object>();
        public Dictionary<string, object> Params { get; } = new Dictionary<string, object>();
        public abstract string BaseUrl { get; }

        public string GetRequestUri() 
        {
            string uri = $"{Path.Combine(BaseUrl, string.Join("/", PathParams))}";

            if(Params.Count > 0) 
            {
                uri = $"{uri}?{string.Join("&", Params.Select(x => $"{x.Key}={x.Value}"))}";
            }

            return uri;
        }

        public HttpRequest()
        {

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OpenMeteoWrapperClient/1.0");
        }

        public abstract class HttpGetRequest<T> : HttpRequest
        {
            public async Task<T> GetAsync()
            {
                HttpResponseMessage response = await _httpClient.GetAsync(GetRequestUri());

                string content = await response.Content.ReadAsStringAsync();

                return await CreateResponse(content);
            }

            protected virtual Task<T> CreateResponse(string json) 
            {
                return Task.FromResult(JsonSerializer.Deserialize<T>(json));
            }

        }
    }
}
