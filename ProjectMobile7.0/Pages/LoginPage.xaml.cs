using System;
using System.Threading.Tasks;

namespace ProjectMobile7._0.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginService _loginService = new LoginService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            bool rememberMe = RememberMeSwitch.IsToggled; 

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageLabel.Text = "Please enter your email and password.";
                MessageLabel.TextColor = Colors.Red;
                return;
            }

            MessageLabel.Text = "Loading...";
            MessageLabel.TextColor = Colors.Red;

            try
            {
                bool isLoginSuccessful = await _loginService.LoginAsync(email, password, rememberMe);

                if (isLoginSuccessful)
                {
                    MessageLabel.Text = "Login successful!";
                    MessageLabel.TextColor = Colors.Green;

                    await Task.Delay(500);  
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    MessageLabel.Text = "Invalid email or password.";
                    MessageLabel.TextColor = Colors.Red;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageLabel.Text = "Network error. Please try again later.";
                MessageLabel.TextColor = Colors.Red;
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = "An unexpected error occurred.";
                MessageLabel.TextColor = Colors.Red;
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
