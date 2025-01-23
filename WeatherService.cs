using Lekcia12_cvicenie;

namespace Lekcia12_Cvicenie
{
    public class WeatherService
    {
        public void ProcessWeatherData(WeatherData weatherData)
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
