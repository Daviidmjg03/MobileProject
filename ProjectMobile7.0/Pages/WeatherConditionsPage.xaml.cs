using Newtonsoft.Json;
using System.Linq;

namespace ProjectMobile7._0.Pages
{
    public partial class WeatherConditionsPage : ContentPage
    {
        private readonly string apiKey = "1e14dcdc8a8035c82aabebb958207c70";
        private readonly double lat = 44.34;  
        private readonly double lon = 10.99; 

        public WeatherConditionsPage()
        {
            InitializeComponent();
            FetchWeatherData();  
        }

        private async void FetchWeatherData()
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}&units=metric";

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(response);
                    var currentWeather = weatherData.List.FirstOrDefault();

                    if (currentWeather != null)
                    {
                        var temperature = currentWeather.Main.Temp;
                        var feelsLike = currentWeather.Main.FeelsLike;
                        var tempMin = currentWeather.Main.TempMin;
                        var tempMax = currentWeather.Main.TempMax;
                        var humidity = currentWeather.Main.Humidity;
                        var pressure = currentWeather.Main.Pressure;
                        var windSpeed = currentWeather.Wind.Speed;
                        var windGust = currentWeather.Wind.Gust;
                        var windDirection = currentWeather.Wind.Deg;
                        var weatherDescription = currentWeather.Weather.FirstOrDefault()?.Description;
                        var clouds = currentWeather.Clouds.All;


                        weatherLabel.Text = $"Temperature: {temperature}°C\n" +
                                            $"Feels Like: {feelsLike}°C\n" +
                                            $"Min Temp: {tempMin}°C\n" +
                                            $"Max Temp: {tempMax}°C\n" +
                                            $"Humidity: {humidity}%\n" +
                                            $"Pressure: {pressure} hPa\n" +
                                            $"Wind Speed: {windSpeed} m/s\n" +
                                            $"Wind Gust: {windGust} m/s\n" +
                                            $"Wind Direction: {windDirection}°\n" +
                                            $"Weather: {weatherDescription}\n" +
                                            $"Cloud Cover: {clouds}%";
                    }
                    else
                    {
                        weatherLabel.Text = "No weather data available.";
                    }
                }
            }
            catch (Exception ex)
            {
                weatherLabel.Text = $"Error fetching weather data: {ex.Message}";
            }
        }
    }
}
