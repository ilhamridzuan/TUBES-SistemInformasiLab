using SistemInformasiLab_Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_Program.Services
{
    public class SistemPendaftaran
    {
        private List<Pasien> daftarAntrian = new List<Pasien>();
        private int batasAntrian;

        public SistemPendaftaran(int batas)
        {
            batasAntrian = batas;
        }

        public void DaftarPasien()
        {
            if (daftarAntrian.Count >= batasAntrian)
            {
                Console.WriteLine("Maaf, kuota pendaftaran hari ini sudah penuh.\n");
                return;
            }

            Dictionary<string, string> dataPasien = new Dictionary<string, string>();

            string[] fieldInput = { "Nama", "NIK", "Jenis Kelamin", "Jenis Pasien", "Keluhan" };

            foreach (string field in fieldInput)
            {
                Console.Write($"{field}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"{field} tidak boleh kosong.\n");
                    return;
                }

                if (field == "NIK")
                {
                    if (input.Length != 16 || !long.TryParse(input, out _))
                    {
                        Console.WriteLine("NIK harus terdiri dari 16 digit angka.\n");
                        return;
                    }
                }

                dataPasien[field] = input;
            }

            Pasien p = new Pasien
            {
                NomorAntrian = daftarAntrian.Count + 1,
                Nama = dataPasien["Nama"],
                NIK = dataPasien["NIK"],
                JenisKelamin = dataPasien["Jenis Kelamin"],
                JenisPasien = dataPasien["Jenis Pasien"],
                Keluhan = dataPasien["Keluhan"],
                WaktuDaftar = DateTime.Now
            };

            daftarAntrian.Add(p);

            Console.WriteLine($"\nPendaftaran berhasil. Nomor antrian Anda: {p.NomorAntrian}\n");
        }

        public void LihatAntrian()
        {
            Console.WriteLine("\n=== DAFTAR ANTRIAN ===");
            if (daftarAntrian.Count == 0)
            {
                Console.WriteLine("Belum ada pasien yang mendaftar.\n");
                return;
            }

            foreach (var p in daftarAntrian)
            {
                Console.WriteLine($"{p.NomorAntrian}. Nama: {p.Nama} | NIK: {p.NIK} | Jenis Kelamin: {p.JenisKelamin} | Jenis Pasien: {p.JenisPasien} | Keluhan: {p.Keluhan} | Waktu: {p.WaktuDaftar}");
            }
            Console.WriteLine();
        }
    }
}
