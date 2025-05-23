using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemInformasiLab_Program.Services;
using SistemInformasiLab_Program.Utils;

namespace SistemInformasiLab_Program.Controllers
{
    public class AuthController
    {
        private readonly HttpService httpService;

        Dashboard dashboard = new Dashboard();
        public AuthController()
        {
            httpService = new HttpService("http://localhost:5031/");
        }

        public async Task ShowMenuAsync()
        {
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM INFORMASI LABORATORIUM ===");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilihan: ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        await HandleRegisterAsync();
                        break;
                    case "2":
                        await HandleLoginAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task HandleRegisterAsync()
        {
            Console.Clear();
            Console.WriteLine("== REGISTRASI AKUN ==");
            try
            {
                Console.Write("Fullname: ");
                string fullname = Console.ReadLine();
                InputValidator.ValidateNotEmpty(fullname, "Fullname");

                Console.Write("Email: ");
                string email = Console.ReadLine();
                InputValidator.ValidateNotEmpty(email, "Email");
                InputValidator.ValidateEmail(email);

                Console.Write("Username: ");
                string username = Console.ReadLine();
                InputValidator.ValidateNotEmpty(username, "Username");
                InputValidator.ValidateMinLength(username, "Username", 4);

                Console.Write("Password: ");
                string password = Console.ReadLine();
                InputValidator.ValidateNotEmpty(password, "Password");
                InputValidator.ValidateMinLength(password, "Password", 8);

                string role = PilihRole();

                var result = await httpService.RegisterAsync(fullname, email, username, password, role);
                Console.WriteLine($"\n{result.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[VALIDASI GAGAL] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }

            Console.ReadKey();
        }

        private string PilihRole()
        {
            while (true)
            {
                Console.WriteLine("\nPilih Role:");
                Console.WriteLine("1. Pasien");
                Console.WriteLine("2. Dokter");
                Console.WriteLine("3. Petugas");
                Console.Write("Pilihan Anda (1-3): ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1": return "pasien";
                    case "2": return "dokter";
                    case "3": return "petugas";
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                        break;
                }
            }
        }

        private async Task<bool> HandleLoginAsync()
        {
            Console.Clear();
            Console.WriteLine("== LOGIN ==");
            try
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                InputValidator.ValidateNotEmpty(username, "Username");

                Console.Write("Password: ");
                string password = Console.ReadLine();
                InputValidator.ValidateNotEmpty(password, "Password");

                var result = await httpService.LoginAsync(username, password);
                Console.WriteLine($"\n{result.Message}");
                if (result.Role != null)
                {
                    Console.WriteLine($"Login sebagai: {result.Role}");
                    if (result.Role == "Pasien")
                    {
                        dashboard.ShowMenuPasien();
                    }
                    else if (result.Role == "Dokter")
                    {
                        dashboard.ShowMenuDokter();
                    }
                    else if (result.Role == "Petugas")
                    {
                        dashboard.ShowMenuPetugas();
                    }
                    return true;
                }
                Console.WriteLine("Login gagal. Tekan tombol untuk mencoba lagi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[VALIDASI GAGAL] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            Console.ReadKey();
            return false;
        }
    }
}
