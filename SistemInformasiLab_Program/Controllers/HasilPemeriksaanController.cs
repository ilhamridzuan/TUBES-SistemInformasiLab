using SistemInformasiLab_Program.Models;
using SistemInformasiLab_Program.Services;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SistemInformasiLab_Program.Controllers
{
    public class HasilPemeriksaanController
    {
        private readonly HasilPemeriksaanClient client;

        public HasilPemeriksaanController()
        {
            client = new HasilPemeriksaanClient();
        }

        public async Task TampilkanSemuaAsync()
        {
            var data = await client.GetAllAsync();
            if (data.Count == 0)
            {
                Console.WriteLine("Belum ada data hasil pemeriksaan.");
            }
            else
            {
                foreach (var item in data)
                {
                    Console.WriteLine($"ID: {item.Id}, Nama: {item.NamaPasien}, Pemeriksaan: {item.JenisPemeriksaan}, Hasil: {item.Hasil}, Tanggal: {item.Tanggal.ToShortDateString()}");
                }
            }
            Console.WriteLine("\\nTekan tombol apapun untuk kembali...");
            Console.ReadKey();
            Console.Clear();
        }

        public async Task TambahAsync()
        {
            var data = BacaInput();
            await client.CreateAsync(data);
        }

        public async Task UpdateAsync()
        {
            Console.Write("Masukkan ID yang ingin diperbarui: ");
            string id = Console.ReadLine();
            var data = BacaInput();
            await client.UpdateAsync(id, data);
        }

        public async Task HapusAsync()
        {
            Console.Write("Masukkan ID yang ingin dihapus: ");
            string id = Console.ReadLine();
            await client.DeleteAsync(id);
        }

        private HasilPemeriksaan BacaInput()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Nama Pasien: ");
            string nama = Console.ReadLine();
            Console.Write("Jenis Pemeriksaan: ");
            string jenis = Console.ReadLine();
            Console.Write("Hasil: ");
            string hasil = Console.ReadLine();
            Console.Write("Tanggal (yyyy-MM-dd): ");
            string tglInput = Console.ReadLine();
            DateTime tanggal = DateTime.ParseExact(tglInput, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return new HasilPemeriksaan
            {
                Id = id,
                NamaPasien = nama,
                JenisPemeriksaan = jenis,
                Hasil = hasil,
                Tanggal = tanggal
            };
        }
    }
}
