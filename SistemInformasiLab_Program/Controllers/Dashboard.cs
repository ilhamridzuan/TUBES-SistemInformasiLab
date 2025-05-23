using Microsoft.Extensions.Configuration;
using SistemInformasiLab_Program.Models;
using SistemInformasiLab_Program.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_Program.Controllers
{
    public class Dashboard
    {
        public Dashboard()
        {
        }

        public void ShowMenuPasien()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Data/KuotaPasien.json")
                .Build();

            int batasAntrian = int.Parse(config["Kuota"]);
            SistemPendaftaran sistem = new SistemPendaftaran(batasAntrian);
            while (true)
            {
                Console.WriteLine("=== SISTEM INFORMASI LABORATORIUM RSUD KAJEN ===");
                Console.WriteLine("1. Pendaftaran");
                Console.WriteLine("2. Antrian");
                Console.WriteLine("3. Lihat Hasil");
                Console.WriteLine("4. History");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        sistem.DaftarPasien();
                        break;
                    case "2":
                        sistem.LihatAntrian();
                        break;
                    case "3":
                        LihatHasilPasien();
                        break;
                    case "4":
                        //TODO : manggil method lihat history
                        break;
                    case "5":
                        Console.WriteLine("Terima kasih.");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia.\n");
                        break;
                }
            }
        }

        public void ShowMenuDokter()
        {
            while (true)
            {
                Console.WriteLine("=== SISTEM INFORMASI LABORATORIUM RSUD KAJEN ===");
                Console.WriteLine("1. Lihat Hasil");
                Console.WriteLine("2. History");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        //TODO : manggil method lihat hasil
                        LihatHasilPasien();
                        break;
                    case "2":
                        //TODO : manggil method lihat history
                        break;
                    case "3":
                        Console.WriteLine("Terima kasih.");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia.\n");
                        break;
                }
            }
        }

        public void ShowMenuPetugas()
        {
            var controller = new HasilPemeriksaanController();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PETUGAS ===");
                Console.WriteLine("1. Lihat Semua Hasil Pemeriksaan");
                Console.WriteLine("2. Tambah Hasil Pemeriksaan");
                Console.WriteLine("3. Update Hasil Pemeriksaan");
                Console.WriteLine("4. Hapus Hasil Pemeriksaan");
                Console.WriteLine("5. Kembali");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        controller.TampilkanSemuaAsync();
                        break;
                    case "2":
                        controller.TambahAsync();
                        break;
                    case "3":
                        controller.UpdateAsync();
                        break;
                    case "4":
                        controller.HapusAsync();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void LihatHasilPasien()
        {
            var konfigurasiService = new KonfigurasiService(); // runtime config loaded here
            var pasienService = new PasienService(konfigurasiService);
            var pemeriksaanService = new PemeriksaanService();

            Console.Write("Masukkan ID Pasien: ");
            var id = Console.ReadLine();

            try
            {
                var pasien = pasienService.CariPasien(id);
                if (pasien == null)
                {
                    Console.WriteLine("Pasien tidak ditemukan.");
                    return;
                }

                pemeriksaanService.TampilkanHasil(pasien);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
