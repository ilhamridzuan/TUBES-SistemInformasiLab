using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemInformasiLab_Program.Models;
using SistemInformasiLab_Program.Services;
using System;
using System.IO;

namespace SistemInformasiLab_Program.Tests
{
    [TestClass]
    public class SistemPendaftaranTests
    {
        [TestMethod]
        public void DaftarPasien_BerhasilSaatKuotaTersedia()
        {
            var sistem = new SistemPendaftaran(2);

            var input = new StringReader("John Doe\n1234567890123456\nLaki-laki\nUmum\nSakit kepala\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            sistem.DaftarPasien();

            string result = output.ToString();
            StringAssert.Contains(result, "Pendaftaran berhasil");
        }

        [TestMethod]
        public void DaftarPasien_GagalSaatKuotaPenuh()
        {
            var sistem = new SistemPendaftaran(0);

            var output = new StringWriter();
            Console.SetOut(output);

            sistem.DaftarPasien();

            var result = output.ToString();
            StringAssert.Contains("Maaf, kuota pendaftaran hari ini sudah penuh", result);
        }

    }
}
