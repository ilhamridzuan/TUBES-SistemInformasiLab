using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using SistemInformasiLab_Program.Models;

namespace SistemInformasiLab_Program.Services
{
    public class HttpService
    {
        private readonly HttpClient _client;

        public HttpService(string baseAddress)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<RegisterResponse> RegisterAsync(string fullname, string email, string username, string password, string role)
        {
            var response = await _client.PostAsJsonAsync("api/auth/register", new
            {
                Fullname = fullname,
                Email = email,
                Username = username,
                Password = password,
                Role = role
            });

            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var response = await _client.PostAsJsonAsync("api/auth/login", new
            {
                Username = username,
                Password = password
            });

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

    }
}
