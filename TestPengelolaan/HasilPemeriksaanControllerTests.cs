using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemInformasiLab_API.Controllers;
using SistemInformasiLab_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LabSystem.Tests
{
    [TestClass]
    public class HasilPemeriksaanControllerTests
    {
        // Controller yang akan dites, diinisialisasi tiap kali test jalan
        private HasilPemeriksaanController? _controller;

        [TestInitialize]
        public void Setup()
        {
            // Ini jalan sebelum setiap test dijalankan
            _controller = new HasilPemeriksaanController();
        }

        [TestMethod]
        public void Create_ValidInput_ReturnsCreatedAtAction()
        {
            // Simulasi input data yang valid
            var input = new HasilPemeriksaan
            {
                Id = Guid.NewGuid().ToString(),
                NamaPasien = "Budi Santoso", // nama sesuai format
                JenisPemeriksaan = "Darah",
                Hasil = "Negatif",
                Tanggal = DateTime.Now
            };

            var result = _controller.Create(input);

            // Harapannya, data tersimpan dan return Created
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void Create_InvalidNamaPasien_ReturnsBadRequest()
        {
            // Coba input nama yang ga valid (ada angka)
            var input = new HasilPemeriksaan
            {
                Id = Guid.NewGuid().ToString(),
                NamaPasien = "1234", // pasti gagal di regex validasi nama
                JenisPemeriksaan = "Urine",
                Hasil = "Positif",
                Tanggal = DateTime.Now
            };

            var result = _controller.Create(input);

            // Karena nama nggak valid, harusnya BadRequest
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetAll_ReturnsListOfHasilPemeriksaan()
        {
            // Panggil method GetAll buat ambil semua data
            var result = _controller.GetAll();

            var okResult = result as OkObjectResult;

            // Harusnya dapat OK dan isinya list
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOfType(okResult.Value, typeof(List<HasilPemeriksaan>));
        }

        [TestMethod]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Cari data dengan ID yang ngasal
            var result = _controller.GetById("invalid-id");

            // Harusnya ketemu NotFound karena data gak ada
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Hapus data yang gak pernah ada
            var result = _controller.Delete("invalid-id");

            // Harusnya juga NotFound
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Update_ValidInput_ReturnsOk()
        {
            // Pertama, simpan dulu data yang valid
            var id = Guid.NewGuid().ToString();
            var original = new HasilPemeriksaan
            {
                Id = id,
                NamaPasien = "Agus Saputra", // nama aman, valid
                JenisPemeriksaan = "Darah",
                Hasil = "Normal",
                Tanggal = DateTime.Now
            };

            var createResult = _controller.Create(original);
            Assert.IsInstanceOfType(createResult, typeof(CreatedAtActionResult)); // pastiin datanya masuk

            // Update data yang tadi disimpan
            var updated = new HasilPemeriksaan
            {
                Id = id,
                NamaPasien = "Agus Saputra", // nama masih valid
                JenisPemeriksaan = "Urine",
                Hasil = "Tinggi",
                Tanggal = DateTime.Now
            };

            var result = _controller.Update(id, updated);

            // Harusnya berhasil dan return OK
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Update_IdNotExist_ReturnsNotFound()
        {
            // Coba update data yang ID-nya gak pernah dibuat
            var updated = new HasilPemeriksaan
            {
                Id = "non-existent-id",
                NamaPasien = "Dummy",
                JenisPemeriksaan = "Tes",
                Hasil = "Tes",
                Tanggal = DateTime.Now
            };

            var result = _controller.Update("wrong-id", updated);

            // Karena datanya gak ada, return-nya harus NotFound
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
