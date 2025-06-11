using SistemInformasiLab_GUI.model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SistemInformasiLab_GUI.controller
{
    public static class PasienController
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5031/")
        };

        public static async Task<PasienModel> TambahPasienAsync(PasienModel pasien)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5031/");
                var response = await client.PostAsJsonAsync("api/pendaftaran", pasien);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PasienModel>();
                    return result;
                }

                return null;
            }
        }

        public static async Task<List<PasienModel>> GetAllPasienAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5031/");
                var response = await client.GetAsync("api/pendaftaran");

                if (response.IsSuccessStatusCode)
                {
                    var list = await response.Content.ReadFromJsonAsync<List<PasienModel>>();
                    return list;
                }

                return new List<PasienModel>();
            }
        }
    }
}
