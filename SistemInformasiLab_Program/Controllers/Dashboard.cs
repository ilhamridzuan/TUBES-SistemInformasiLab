using Microsoft.Extensions.Configuration;
using SistemInformasiLab_Program.Services;
using System;
using System.Collections.Generic;
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
                Console.WriteLine("3. Lihar Hasil");
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
                        //TODO : manggil method lihat hasil
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
                Console.WriteLine("1. Lihar Hasil");
                Console.WriteLine("2. History");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        //TODO : manggil method lihat hasil
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
            //TODO : Tambahin menu untuk petugas
        }
    }
}
