
using OpenMeteoWrapper.Models;
using OpenMeteoWrapper.Options;
using OpenMeteoWrapper.Processors;
using System.Net.Http;

namespace OpenMeteoWrapper
{
    public class OMClient
    {
        public OMClient()
        {
            
        }

        public async Task<WeatherForecastModel> GetWeatherFromCityName(string location, WeatherForecastOptions weatherOptions) 
        {
            GeocodingOptions options = new GeocodingOptions(location);

            GeocodingResponseModel locRequest = await new GetGeolocation(options).GetAsync();

            if (locRequest == null || locRequest.Locations == null)
                return null;

            weatherOptions.Longitude = locRequest.Locations[0].Longitude;
            weatherOptions.Latitude = locRequest.Locations[0].Latitude;
            
            return await new GetWeather(weatherOptions).GetAsync();
        }

    }

}
