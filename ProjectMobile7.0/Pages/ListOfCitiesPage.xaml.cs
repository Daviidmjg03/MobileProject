using Newtonsoft.Json;

namespace ProjectMobile7._0.Pages
{
    public partial class ListOfCitiesPage : ContentPage
    {
        private readonly string apiKey = "1e14dcdc8a8035c82aabebb958207c70";

        public ListOfCitiesPage()
        {
            InitializeComponent();
            FetchCitiesWeatherData();  
        }

        private async void FetchCitiesWeatherData()
        {
            try
            {
                var cities = new List<string>
                {
                    "Zocca", "Rome", "Milan", "Florence", "Venice", "Turin", "Naples", "Bologna", "Genoa", "Palermo",
                    "Catania", "Bari", "Verona", "Messina", "Padua", "Trieste", "Brescia", "Prato", "Reggio Calabria", "Modena",
                    "Parma", "Livorno", "Foggia", "Perugia", "Ravenna", "Cagliari", "Siena", "Lecce", "Ancona", "Salerno"
                };

                var cityWeatherList = new List<City>();

                using (HttpClient client = new HttpClient())
                {
                    foreach (var city in cities)
                    {
                        string url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=metric";
                        var response = await client.GetStringAsync(url);
                        var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(response);

                        if (weatherData != null && weatherData.List.Any())
                        {
                            var firstForecast = weatherData.List.First();

                            cityWeatherList.Add(new City
                            {
                                Name = city,
                                Temperature = firstForecast.Main.Temp, 
                                WeatherDescription = firstForecast.Weather[0]?.Description, 
                                Humidity = firstForecast.Main.Humidity,
                                Pressure = firstForecast.Main.Pressure,
                                WindSpeed = firstForecast.Wind.Speed,
                                WindGust = firstForecast.Wind.Gust,
                                WindDirection = firstForecast.Wind.Deg
                            });
                        }
                    }
                }

                citiesListView.ItemsSource = cityWeatherList;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error fetching weather data: {ex.Message}", "OK");
            }
        }

        private async void OnCitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCity = e.SelectedItem as City;

            if (selectedCity != null)
            {
                await Navigation.PushAsync(new WeatherDetailsPage(selectedCity));
            }
            citiesListView.SelectedItem = null;
        }
    }
}
