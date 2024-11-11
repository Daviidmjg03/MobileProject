using ProjectMobile7._0.Pages;

namespace ProjectMobile7._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private bool isMenuOpen = false;

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }

        private void OpenMenu(object sender, EventArgs e)
        {
            if (isMenuOpen)
            {
                MenuColumn.Width = new GridLength(0);
                ContentColumn.Width = new GridLength(1, GridUnitType.Star); 
            }
            else
            {
                MenuColumn.Width = new GridLength(200); 
                ContentColumn.Width = new GridLength(1, GridUnitType.Star);
            }

            isMenuOpen = !isMenuOpen;
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherConditionsPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListOfCountriesPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListOfCitiesPage());
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
