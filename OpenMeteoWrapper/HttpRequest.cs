using OpenMeteoWrapper.Models;
using OpenMeteoWrapper.Options;
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
        public HourlyOptions? HourlyParams { get; set; }
        public AirQualityOptions.HourlyOptions? AirHourlyParams { get; set; }
        public DailyOptions? DailyParams { get; set; }

        public CellSelectionType? Cell_Selection { get; set; }

        public WeatherModelOptions? ModelsParams { get; set; }
        public CurrentOptions? CurrentParams { get; set; }
        public Minutely15Options? Minutely15Params { get; set; }
        public abstract string BaseUrl { get; }

        public string GetRequestUri() 
        {
            string uri = $"{Path.Combine(BaseUrl, string.Join("/", PathParams))}";

            if(Params != null) 
            {
                bool firstElement = true;
                uri = $"{uri}?";

                if (firstElement)
                {
                    uri = $"{uri}{Params.First().Key}={Params.First().Value}";
                    Params.Remove(Params.First().Key);
                    firstElement = false;
                }
                else 
                {
                    uri = $"{uri}{string.Join("&", Params.Select(x => $"{x.Key}={x.Value}"))}";
                }
            }

            if(HourlyParams != null) 
            {
                bool firstElement = true;
                uri += "&hourly=";

                foreach(var option in HourlyParams) 
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else 
                    {
                        uri += $",{option}";
                    }
                }
            }
            if(DailyParams != null) 
            {
                bool firstElement = true;
                uri += "&daily=";

                foreach(var option in DailyParams) 
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else 
                    {
                        uri += $",{option}";
                    }
                }
            }
            if(Cell_Selection != null)
                uri += $"&cell_selection={Cell_Selection.ToString().ToLower()}";
            if (ModelsParams != null) 
            {
                bool firstElement = true;
                uri += "&models=";

                foreach(var option in ModelsParams) 
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else 
                    {
                        uri += $",{option}";
                    }
                }
            }
            if(CurrentParams != null) 
            {
                bool firstElement = true;
                uri += "&current=";

                foreach(var option in CurrentParams) 
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else 
                    {
                        uri += $",{option}";
                    }
                }
            }
            if(Minutely15Params != null) 
            {
                bool firstElement = true;
                uri += "&minutely_15=";

                foreach(var option in Minutely15Params) 
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else 
                    {
                        uri += $",{option}";
                    }
                }
            }
            if (AirHourlyParams != null)
            {
                bool firstElement = true;
                uri += "&hourly=";

                foreach (var option in AirHourlyParams)
                {
                    if (firstElement)
                    {
                        uri += option.ToString();
                        firstElement = false;
                    }
                    else
                    {
                        uri += $",{option}";
                    }
                }
            }



            return uri;
        }

        public HttpRequest()
        {

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OpenMeteoWrapperClient/1.0");
        }   
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
    public abstract class HttpGetRequestCI<T> : HttpRequest
    {
        public async Task<T> GetAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(GetRequestUri());

            var content = await response.Content.ReadAsStreamAsync();

            return await CreateResponse(content);
        }

        protected virtual Task<T> CreateResponse(Stream json)
        {
            return Task.FromResult(JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true}));
        }

    }
}
