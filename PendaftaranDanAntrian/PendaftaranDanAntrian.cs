using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemInformasiLab_Program.Services;
using SistemInformasiLab_Program.Models;
using System;
using System.IO;
using System.Text;

namespace SistemInformasiLab_Program.Tests
{
    [TestClass]
    public class SistemPendaftaranTests
    {
        [TestMethod]
        public void DaftarPasien_BerhasilSaatKuotaTersedia()
        {
            var sistem = new SistemPendaftaran(1);
            var input = new StringReader("Alfian\n1234567890123456\nLaki-laki\nUmum\nDemam\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);

            sistem.DaftarPasien();
            string hasil = output.ToString();

            StringAssert.Contains(hasil, "Pendaftaran berhasil");
        }

        [TestMethod]
        public void DaftarPasien_GagalSaatKuotaPenuh()
        {
            var sistem = new SistemPendaftaran(0);
            var output = new StringWriter();
            Console.SetOut(output);

            sistem.DaftarPasien();
            string hasil = output.ToString();

            StringAssert.Contains(hasil, "kuota pendaftaran hari ini sudah penuh");
        }

        [TestMethod]
        public void DaftarPasien_GagalJikaNIKTidakValid()
        {
            var sistem = new SistemPendaftaran(1);
            var input = new StringReader("Avriela\n123\nPerempuan\nUmum\nPusing\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);

            sistem.DaftarPasien();
            string hasil = output.ToString();

            StringAssert.Contains(hasil, "NIK harus terdiri dari 16 digit angka");
        }
    }
}
