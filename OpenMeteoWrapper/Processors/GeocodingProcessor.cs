using OpenMeteoWrapper.Models;
using OpenMeteoWrapper.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteoWrapper.Processors
{
    public class GetGeolocation : HttpGetRequest<GeocodingResponseModel>
    {
        public override string BaseUrl => "https://geocoding-api.open-meteo.com/v1/search";

        public GetGeolocation(GeocodingOptions options) 
        {
            Params.Add("name", options.Name);
            if(options.Count > 0) 
            {
                Params.Add("count", options.Count);
            }
            Params.Add("format", options.Format);
            Params.Add("language", options.Language);
            
        }
    }
}
