using Lekcia12_Cvicenie;

namespace Lekcia12_cvicenie
{
    internal class Program
    {

        private static async Task Main(string[] args)
        {
            {
                const string apiKey = "1e938ad66b7a466badd61544250101";
                const string location = "Bratislava";
                const int days = 10;

                string apiUrl = $"http://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&days={days}&aqi=no&alerts=no&lang=sk";

                var apiClient = new WeatherApiClient();
                var weatherService = new WeatherService();

                try
                {
                    Console.WriteLine("Sťahujem údaje z WeatherAPI...");
                    var weatherData = await apiClient.FetchWeatherData(apiUrl);

                    Console.WriteLine("Spracovávam údaje...");
                    weatherService.ProcessWeatherData(weatherData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Vyskytla sa chyba: {ex.Message}");
                }
            }
        }
    }
}