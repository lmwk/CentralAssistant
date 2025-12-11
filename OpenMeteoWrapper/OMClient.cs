
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

        public async Task<WeatherForecastModel> GetWeatherFromCityName(string location)
        {
            GeocodingOptions options = new GeocodingOptions(location);

            GeocodingResponseModel locRequest = await new GetGeolocation(options).GetAsync();

            if (locRequest == null || locRequest.Locations == null)
                return null;

            WeatherForecastOptions weatherOptions = new WeatherForecastOptions
            {
                Longitude = locRequest.Locations[0].Longitude,
                Latitude = locRequest.Locations[0].Latitude,
                Current = CurrentOptions.All
            };

            return await new GetWeather(weatherOptions).GetAsync();
        }

        public async Task<WeatherForecastModel> GetWeatherForecast(GeocodingOptions options) 
        {
            GeocodingResponseModel? locRequest = await new GetGeolocation(options).GetAsync();

            if(locRequest == null || locRequest.Locations == null)
                return null;

            WeatherForecastOptions weatherForecastOptions = new WeatherForecastOptions
            {
                Latitude = locRequest.Locations[0].Latitude,
                Longitude = locRequest.Locations[0].Longitude,
                Current = CurrentOptions.All
            };

            return await new GetWeather(weatherForecastOptions).GetAsync();
        }

        public async Task<WeatherForecastModel> GetWeatherForecast(WeatherForecastOptions options) 
        {
            try
            {
                return await new GetWeather(options).GetAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<WeatherForecastModel> GetWeatherForecast(float latitude, float longitude) 
        {
            WeatherForecastOptions weatherForecastOptions = new WeatherForecastOptions
            {
                Latitude = latitude,
                Longitude = longitude,
                Current = CurrentOptions.All
            };
            return await new GetWeather(weatherForecastOptions).GetAsync();
        }

        public string WeathercodeToString(int weathercode)
        {
            
        }

    }

}
