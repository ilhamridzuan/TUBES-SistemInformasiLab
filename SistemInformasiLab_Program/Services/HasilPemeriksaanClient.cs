using SistemInformasiLab_Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_Program.Services
{
    public class HasilPemeriksaanClient
    {
        private readonly HttpClient _client;

        public HasilPemeriksaanClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5031/api/HasilPemeriksaan");
        }

        public async Task<List<HasilPemeriksaan>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<HasilPemeriksaan>>("");
        }

        public async Task CreateAsync(HasilPemeriksaan data)
        {
            var response = await _client.PostAsJsonAsync("", data);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Hasil pemeriksaan berhasil ditambahkan.");
        }

        public async Task UpdateAsync(string id, HasilPemeriksaan data)
        {
            var response = await _client.PutAsJsonAsync($"/{id}", data);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Hasil pemeriksaan berhasil diperbarui.");
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _client.DeleteAsync($"/{id}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Hasil pemeriksaan berhasil dihapus.");
        }
    }
}
