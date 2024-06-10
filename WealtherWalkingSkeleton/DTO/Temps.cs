using System.Text.Json.Serialization;

namespace WealtherWalkingSkeleton.DTO
{
    public class Temps
    {
        [JsonPropertyName("temp")]
        public decimal Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public decimal TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public decimal TempMax { get; set; }
    }
}
