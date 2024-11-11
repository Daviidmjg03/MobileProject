using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ProjectMobile7._0.Pages
{
    public partial class ListOfCountriesPage : ContentPage
    {
        private readonly string apiKey = "1e14dcdc8a8035c82aabebb958207c70";

        private List<City> cityWeatherList = new List<City>();

        public ListOfCountriesPage()
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
                                Country = weatherData.City.Country, 
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

                var countries = cityWeatherList
                    .GroupBy(city => city.Country)
                    .Select(group => new
                    {
                        Country = group.Key,
                        CityNames = string.Join(", ", group.Select(city => city.Name)) 
                    })
                    .ToList();

                countriesListView.ItemsSource = countries;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error fetching weather data: {ex.Message}", "OK");
            }
        }

        private async void OnCountrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCountry = e.SelectedItem as dynamic;

            if (selectedCountry != null)
            {
                await DisplayAlert("Selected Country", $"Country: {selectedCountry.Country}\nCities: {selectedCountry.CityNames}", "OK");
            }

            // Desmarcar o item selecionado
            countriesListView.SelectedItem = null;
        }
    }
}
