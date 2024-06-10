using System.Text.Json.Serialization;
using WealtherWalkingSkeleton.DTO;

namespace WealtherWalkingSkeleton.Models
{
    public class OpenWeatherResponse
    {
        [JsonPropertyName("list")]
        public List<Forecast> Forecasts { get; set; }
    }
}
