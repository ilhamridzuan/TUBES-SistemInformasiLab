using Microsoft.AspNetCore.Mvc;
using SistemInformasiLab_API.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemInformasiLab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendaftaranController : ControllerBase
    {
        private static List<PasienModel> daftarPasien = new List<PasienModel>();

        // GET: api/pendaftaran
        [HttpGet]
        public ActionResult<List<PasienModel>> GetAll()
        {
            return Ok(daftarPasien);
        }

        // GET: api/pendaftaran/kuota
        [HttpGet("kuota")]
        public ActionResult<object> GetKuota()
        {
            int kuotaMax = GetKuotaMaxFromJson();
            int sisa = kuotaMax - daftarPasien.Count;
            return Ok(new { KuotaMax = kuotaMax, Terpakai = daftarPasien.Count, Sisa = sisa });
        }

        // POST: api/pendaftaran
        [HttpPost]
        public ActionResult<PasienModel> Create([FromBody] PasienModel pasien)
        {
            int kuotaMax = GetKuotaMaxFromJson();

            if (daftarPasien.Count >= kuotaMax)
                return BadRequest("Kuota penuh.");

            pasien.NomorAntrian = daftarPasien.Count + 1;
            pasien.TanggalDaftar = DateTime.UtcNow;

            daftarPasien.Add(pasien);

            return Ok(pasien);
        }

        private int GetKuotaMaxFromJson()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kuota.json");
                if (!System.IO.File.Exists(path)) return 20;

                string json = System.IO.File.ReadAllText(path);
                using var doc = JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("KuotaMax", out var kuota))
                {
                    return kuota.GetInt32();
                }
            }
            catch { }

            return 20; // default jika gagal membaca
        }
    }
}
