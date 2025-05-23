
using Microsoft.AspNetCore.Mvc;
using SistemInformasiLab_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SistemInformasiLab_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HasilPemeriksaanController : ControllerBase
    {
        private static readonly List<HasilPemeriksaan> _data = new List<HasilPemeriksaan>();

        // DFA-style validation: NamaPasien hanya boleh huruf dan spasi
        private bool ValidasiNama(string nama)
        {
            var dfaRegex = new Regex(@"^[A-Za-z ]+$");
            return dfaRegex.IsMatch(nama);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] HasilPemeriksaan input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!ValidasiNama(input.NamaPasien))
                return BadRequest("Nama pasien hanya boleh berisi huruf dan spasi.");

            _data.Add(input);
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _data.FirstOrDefault(x => x.Id == id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] HasilPemeriksaan updated)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!ValidasiNama(updated.NamaPasien))
                return BadRequest("Nama pasien hanya boleh berisi huruf dan spasi.");

            var existing = _data.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();

            existing.NamaPasien = updated.NamaPasien;
            existing.JenisPemeriksaan = updated.JenisPemeriksaan;
            existing.Hasil = updated.Hasil;
            existing.Tanggal = updated.Tanggal;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existing = _data.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();

            _data.Remove(existing);
            return NoContent();
        }
    }
}
