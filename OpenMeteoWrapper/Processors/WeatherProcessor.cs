using OpenMeteoWrapper.Models;
using OpenMeteoWrapper.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenMeteoWrapper.Processors
{
    public class GetWeather : HttpGetRequest<WeatherForecastModel>
    {
        public override string BaseUrl => "https://api.open-meteo.com/v1/forecast";

        public GetWeather(WeatherForecastOptions options) 
        {
            if(options == null)
                throw new ArgumentNullException(nameof(options));

            Params.Add("latitude", options.Latitude.ToString(CultureInfo.InvariantCulture));
            Params.Add("longitude", options.Longitude.ToString(CultureInfo.InvariantCulture));
            Params.Add("temperature_unit", options.Temperature_Unit);
            Params.Add("windspeed_unit", options.Windspeed_Unit.ToString());
            Params.Add("precipitation_unit", options.Precipitation_Unit.ToString());
            if (options.Timezone != string.Empty)
                Params.Add("timezone", options.Timezone);
            Params.Add("timeformat", options.Timeformat);
            Params.Add("past_days", options.Past_Days);
            if (options.Start_date != string.Empty)
                Params.Add("start_date", options.Start_date);
            if (options.End_date != string.Empty)
                Params.Add("end_date", options.End_date);
            if(options.Hourly.Count > 0) 
            {
                HourlyParams = options.Hourly;
            }
            if(options.Daily.Count > 0) 
            {
                DailyParams = options.Daily;
            }
            if(options.Current.Count > 0) 
            {
                CurrentParams = options.Current;
            }
            Cell_Selection = options.Cell_Selection;
            if(options.Models.Count > 0) 
            {
                ModelsParams = options.Models;
            }
            if(options.Minutely15.Count > 0) 
            {
                Minutely15Params = options.Minutely15;
            }

        }
    }
}
