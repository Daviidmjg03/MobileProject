using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectMobile7._0
{
    public class LoginService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string LoginApiUrl = "https://liganosweb.somee.com/api/AccountApi/Login";  

        public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
        {
            var loginData = new { Username = username, Password = password, RememberMe = rememberMe };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(LoginApiUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer login: {ex.Message}");
                return false;
            }
        }

    }
}
