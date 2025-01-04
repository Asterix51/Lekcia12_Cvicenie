using System.Text.Json;
using static Lekcia12_cvicenie.JsonDeserializace;

namespace Lekcia12_cvicenie
{
    internal class Program
    {

        private static async Task Main(string[] args)
        {
            await PublicWeatherAPI();
        }

        private static async Task PublicWeatherAPI()
        {
            const string apiKey = "1e938ad66b7a466badd61544250101";
            const string location = "Bratislava";
            const int days = 10;
            string apiUrl = $"http://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&days={days}&aqi=no&alerts=no&lang=sk";

            Console.WriteLine("Sťahujem údaje z WeatherAPI ...");
            var weatherData = await FetchWeatherData(apiUrl);

            if (weatherData != null)
            {
                Console.WriteLine("Spracovávam údaje...");
                ProcessWeatherData(weatherData);
            }
            else
            {
                Console.WriteLine("Nepodarilo sa získať údaje.");
            }
        }

        private static async Task<WeatherData> FetchWeatherData(string url)
        {
            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<WeatherData>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chyba pri sťahovaní údajov: {e.Message}");
                return null;
            }
        }

        public static void ProcessWeatherData(WeatherData weatherData)
        {
            // Aktuálne počasie
            Console.WriteLine("Aktuálne počasie:");
            Console.WriteLine($"Mesto: {weatherData.Location.Name}");
            Console.WriteLine($"Krajina: {weatherData.Location.Country}");
            Console.WriteLine($"Teplota: {weatherData.Current.TempC}°C");
            Console.WriteLine($"Podmienky: {weatherData.Current.Condition.Text}");
            Console.WriteLine($"Vietor: {weatherData.Current.WindKph} km/h");

            // Predpoveď počasia
            Console.WriteLine("\nPredpoveď počasia:");
            foreach (var day in weatherData.Forecast.ForecastDay)
            {
                string formattedDate = DateTime.Parse(day.Date).ToString("dd.MM.yyyy");
                Console.WriteLine($"Dátum: {formattedDate}");
                Console.WriteLine($"  Max teplota: {day.Day.MaxTempC}°C");
                Console.WriteLine($"  Min teplota: {day.Day.MinTempC}°C");
                Console.WriteLine($"  Podmienky: {day.Day.Condition.Text}");
                Console.WriteLine($"  Pravdepodobnosť dažďa: {day.Day.DailyChanceOfRain}%\n");
            }
        }
    }
}