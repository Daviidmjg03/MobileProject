namespace ProjectMobile7._0.Pages
{
    public partial class WeatherDetailsPage : ContentPage
    {
        public WeatherDetailsPage(City selectedCity)
        {
            InitializeComponent();

            cityNameLabel.Text = selectedCity.Name;
            temperatureLabel.Text = $"Temperature: {selectedCity.Temperature}°C";
            weatherDescriptionLabel.Text = $"Weather: {selectedCity.WeatherDescription}";
            humidityLabel.Text = $"Humidity: {selectedCity.Humidity}%";
            pressureLabel.Text = $"Pressure: {selectedCity.Pressure} hPa";
            windSpeedLabel.Text = $"Wind Speed: {selectedCity.WindSpeed} m/s";
            windGustLabel.Text = $"Wind Gust: {selectedCity.WindGust} m/s";
            windDirectionLabel.Text = $"Wind Direction: {selectedCity.WindDirection}°";
        }
    }
}
