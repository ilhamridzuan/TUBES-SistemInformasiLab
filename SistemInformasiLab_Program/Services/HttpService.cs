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
            if (string.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentException("Base URL tidak boleh kosong.");

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

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                return new RegisterResponse { Message = $"Registrasi gagal: {response.StatusCode} - {error}" };
            }

            return await response.Content.ReadFromJsonAsync<RegisterResponse>()
                   ?? new RegisterResponse { Message = "Registrasi gagal: respons tidak valid." };
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var response = await _client.PostAsJsonAsync("api/auth/login", new
            {
                Username = username,
                Password = password
            });

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                return new LoginResponse { Message = $"Login gagal: {response.StatusCode} - {error}", Role = null };
            }

            return await response.Content.ReadFromJsonAsync<LoginResponse>()
                   ?? new LoginResponse { Message = "Login gagal: respons tidak valid.", Role = null };
        }

    }
}
