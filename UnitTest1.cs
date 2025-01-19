using FluentAssertions;
using Lekcia12_cvicenie;
using Lekcia12_Cvicenie;
using Moq;
using System.Text.Json;
namespace Lekcia13_Cvicenie
{
    public class WeatherApiClientTests
    {
        [Test]
        public async Task FetchWeatherData_ShouldReturnData_WhenApiCallIsSuccessful()
        {
            var mockApiClient = new Mock<WeatherApiClient>();
            string fakeApiResponse = "{ \"location\": { \"name\": \"Bratislava\" }, \"current\": { \"temp_c\": 5.5, \"condition\": { \"text\": \"Clear\" }, \"wind_kph\": 10.2 }, \"forecast\": { \"forecastday\": [] } }";
            mockApiClient
                .Setup(x => x.FetchWeatherData(It.IsAny<string>()))
                .ReturnsAsync(JsonSerializer.Deserialize<WeatherData>(fakeApiResponse));

            var result = await mockApiClient.Object.FetchWeatherData("http://fakeapi.com");

            result.Should().NotBeNull();
            result.Location.Name.Should().Be("Bratislava");
            result.Current.TempC.Should().Be(5.5);
            result.Current.Condition.Text.Should().Be("Clear");
        }

        [Test]
        public async Task FetchWeatherData_ShouldThrowException_WhenApiCallFails()
        {
            var mockApiClient = new Mock<WeatherApiClient>();
            mockApiClient
                .Setup(x => x.FetchWeatherData(It.IsAny<string>()))
                .ThrowsAsync(new Exception("API call failed"));

            Func<Task> act = async () => await mockApiClient.Object.FetchWeatherData("http://invalidapi.com");
            await act.Should().ThrowAsync<Exception>().WithMessage("API call failed");
        }
    }

    public class WeatherServiceTests
    {
        [Test]
        public void ProcessWeatherData_ShouldPrintWeatherInformation_WhenDataIsValid()
        {
            // Arrange
            var weatherService = new WeatherService();
            var weatherData = new WeatherData
            {
                Location = new Location { Name = "Bratislava", Country = "Slovakia" },
                Current = new CurrentWeather { TempC = 5.5f, Condition = new Condition { Text = "Clear" }, WindKph = 10.2f },
                Forecast = new Forecast
                {
                    ForecastDay = new List<ForecastDay>
                    {
                        new ForecastDay
                        {
                            Date = "2025-01-19",
                            Day = new Day { MaxTempC = 8.0f, MinTempC = 2.0f, Condition = new Condition { Text = "Sunny" }, DailyChanceOfRain = 10 }
                        }
                    }
                }
            };

            weatherService.ProcessWeatherData(weatherData);
        }
    }
}