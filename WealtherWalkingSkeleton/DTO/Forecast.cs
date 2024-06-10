using System.Text.Json.Serialization;

namespace WealtherWalkingSkeleton.DTO
{
    public class Forecast
    {
        [JsonPropertyName("dt")]
        public int Dt { get; set; }
        [JsonPropertyName("main")]
        public Temps Temps { get; set; }
    }
}
