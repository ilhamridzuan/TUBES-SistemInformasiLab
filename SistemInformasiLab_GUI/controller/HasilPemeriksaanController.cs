using SistemInformasiLab_GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_GUI.controller
{
    class HasilPemeriksaanController
    {
        // Instance dari HttpClient untuk melakukan HTTP request ke API.
        private readonly HttpClient _httpClient;

        // Base URL dari endpoint API yang digunakan.
        private readonly string _baseUrl = "http://localhost:5031/api/HasilPemeriksaan";

        /// <summary>
        /// Constructor untuk inisialisasi HttpClient.
        /// </summary>
        public HasilPemeriksaanController()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Mengambil seluruh data hasil pemeriksaan dari server API.
        /// </summary>
        /// <returns>List dari objek HasilPemeriksaan atau list kosong jika gagal.</returns>
        public async Task<List<HasilPemeriksaan>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<HasilPemeriksaan>>(_baseUrl);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR][GET] Gagal mengambil data: {ex.Message}");
                return new List<HasilPemeriksaan>();
            }
        }

        /// <summary>
        /// Menambahkan data hasil pemeriksaan ke server melalui API.
        /// </summary>
        /// <param name="data">Objek hasil pemeriksaan yang akan dikirim.</param>
        /// <returns>True jika berhasil, false jika gagal.</returns>
        public async Task<bool> Insert(HasilPemeriksaan data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, data);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR][POST] Gagal mengirim data: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Memperbarui data hasil pemeriksaan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID data yang ingin diperbarui.</param>
        /// <param name="data">Data baru hasil pemeriksaan.</param>
        /// <returns>True jika berhasil, false jika gagal.</returns>
        public async Task<bool> Update(string id, HasilPemeriksaan data)
        {
            try
            {
                var url = $"{_baseUrl}/{id}";
                var response = await _httpClient.PutAsJsonAsync(url, data);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR][PUT] Gagal memperbarui data: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Menghapus data hasil pemeriksaan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID data yang akan dihapus.</param>
        /// <returns>True jika berhasil, false jika gagal.</returns>
        public async Task<bool> Delete(string id)
        {
            try
            {
                var url = $"{_baseUrl}/{id}";
                var response = await _httpClient.DeleteAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR][DELETE] Gagal menghapus data: {ex.Message}");
                return false;
            }
        }
    }
}