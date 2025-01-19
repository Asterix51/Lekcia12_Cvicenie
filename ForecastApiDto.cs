using System.Text.Json.Serialization;

namespace Lekcia12_cvicenie
{

    public class WeatherData
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("temp_c")]
        public double TempC { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("wind_kph")]
        public float WindKph { get; set; }
    }

    public class Condition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public List<ForecastDay> ForecastDay { get; set; }
    }

    public class ForecastDay
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("day")]
        public Day Day { get; set; }
    }

    public class Day
    {
        [JsonPropertyName("maxtemp_c")]
        public float MaxTempC { get; set; }

        [JsonPropertyName("mintemp_c")]
        public float MinTempC { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("daily_chance_of_rain")]
        public int DailyChanceOfRain { get; set; }
    }
}