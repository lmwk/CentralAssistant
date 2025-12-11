using OpenMeteoWrapper.Models;
using OpenMeteoWrapper.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteoWrapper.Processors
{
    public class GetAirQuality : HttpGetRequestCI<AirQualityModel>
    {
        public override string BaseUrl => "https://air-quality-api.open-meteo.com/v1/air-quality";

        public GetAirQuality(AirQualityOptions options) 
        {
            Params.Add("latitude", options.Latitude);
            Params.Add("longitude", options.Longitude);
            if(options.Domains != string.Empty)
                Params.Add("domains", options.Domains);
            if (options.TimeFormat != string.Empty)
                Params.Add("timeformat", options.TimeFormat);
            if (options.Timezone != string.Empty)
                Params.Add("timezone", options.Timezone);
            AirHourlyParams = options.Hourly;
        }
    }
}
