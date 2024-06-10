using WealtherWalkingSkeleton.Models;

namespace WealtherWalkingSkeleton.Services
{
    public enum Unit
    {
        Metric,
        Imperial,
        Kelvin
    }
    public interface IOpenWeatherService
    {
        Task<List<WeatherForecast>> GetFiveDayForecast(string location, Unit unit = Unit.Metric);
    }
}
