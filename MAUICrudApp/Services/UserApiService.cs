using MAUICrudApp.Models;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MAUICrudApp.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://10.0.2.2:7153/api/User";

        public UserApiService()
        {
            _httpClient = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            })
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>(BaseUrl);
                return response ?? new List<User>();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error during HTTP request: {httpEx.Message}");
                return new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new List<User>();
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<User>($"{BaseUrl}/{id}");
                return response;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error during HTTP request: {httpEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, user);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User successfully added!");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to add user. Status Code: {response.StatusCode}, Error: {errorMessage}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", user);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error during HTTP request: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error during HTTP request: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
