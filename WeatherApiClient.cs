using System.Text.Json;
using Lekcia12_cvicenie;

namespace Lekcia12_Cvicenie
{
    public class WeatherApiClient
    {
        private readonly HttpClient _httpClient;

        public WeatherApiClient()
        {
            _httpClient = new HttpClient();
        }

        public virtual async Task<WeatherData> FetchWeatherData(string apiUrl)
        {
            try
            {
                string response = await _httpClient.GetStringAsync(apiUrl);
                return JsonSerializer.Deserialize<WeatherData>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri sťahovaní údajov: {ex.Message}");
                throw;
            }
        }
    }
}
