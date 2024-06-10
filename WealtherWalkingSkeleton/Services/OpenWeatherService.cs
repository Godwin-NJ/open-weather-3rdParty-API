using Microsoft.Extensions.Options;
using System.Text.Json;
using WealtherWalkingSkeleton.DTO;
using WealtherWalkingSkeleton.Models;

namespace WealtherWalkingSkeleton.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeather _openWeatherConfig;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpFactory;


        public OpenWeatherService(IOptions<OpenWeather> opts, IConfiguration configuration, IHttpClientFactory httpFactory)
        {
            _openWeatherConfig = opts.Value;
            _configuration = configuration;
            _httpFactory = httpFactory;
        }

        public async Task<List<WeatherForecast>> GetFiveDayForecast(string location, Unit unit = Unit.Metric)
        {
            //string url = $"https://api.openweathermap.org/data/2.5/forecast?q={location}&appid={_openWeatherConfig.ApiKey}&units={unit}";
            // string url = $"https://api.openweathermap.org/data/2.5/forecast?q={location}&appid={_configuration.GetSection("OpenWeatherApiKey").Value}&units={unit}";
            string url = BuildOpenWeatherUrl("forecast", location, unit);
            var forecasts = new List<WeatherForecast>();
            var client = _httpFactory.CreateClient();
            var response = await client.GetAsync(url);
               // Console.WriteLine(response);
                var json = await  response.Content.ReadAsStringAsync();
                var openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(json);
                foreach (var forecast in openWeatherResponse.Forecasts)
                {
                    forecasts.Add(new WeatherForecast
                    {
                        Date = new DateTime(forecast.Dt),
                        Temp = forecast.Temps.Temp,
                        FeelsLike = forecast.Temps.FeelsLike,
                        TempMin = forecast.Temps.TempMin,
                        TempMax = forecast.Temps.TempMax,
                    });
                }
          
            return forecasts;
        }

        private string BuildOpenWeatherUrl(string resource, string location, Unit unit)
        {
            return $"https://api.openweathermap.org/data/2.5/{resource}" +
                   $"?appid={_configuration.GetSection("OpenWeatherApiKey").Value}" +
                   $"&q={location}" +
                   $"&units={unit}";
        }

    }

}
