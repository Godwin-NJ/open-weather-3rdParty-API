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


        public OpenWeatherService(IOptions<OpenWeather> opts, IConfiguration configuration)
        {
            _openWeatherConfig = opts.Value;
            _configuration = configuration;
        }

        public List<WeatherForecast> GetFiveDayForecast(string location, Unit unit = Unit.Metric)
        {
            //string url = $"https://api.openweathermap.org/data/2.5/forecast?q={location}&appid={_openWeatherConfig.ApiKey}&units={unit}";
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={location}&appid={_configuration.GetSection("OpenWeatherApiKey").Value}&units={unit}";
            var forecasts = new List<WeatherForecast>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
               // Console.WriteLine(response);
                var json = response.Content.ReadAsStringAsync().Result;
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
            }
            return forecasts;
        }

    }

}
