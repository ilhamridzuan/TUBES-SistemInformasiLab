using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemInformasiLab_Program.Models;
using System;
using System.IO;

[TestClass]
public class PemeriksaanServiceTests
{
    [TestMethod]
    public void TampilkanHasil_ShouldPrintExpectedOutput_ForDummyPasien()
    {
        // Arrange
        var konfigurasiService = new KonfigurasiService();
        var pasienService = new PasienService(konfigurasiService);
        var pemeriksaanService = new PemeriksaanService();
        var pasien = pasienService.CariPasien("0101010101010101");

        Assert.IsNotNull(pasien, "Pasien tidak ditemukan");

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            pemeriksaanService.TampilkanHasil(pasien);

            // Assert
            var output = sw.ToString();

            Assert.IsTrue(output.Contains("Hemoglobin"));
            Assert.IsTrue(output.Contains("Leukosit"));
            Assert.IsTrue(output.Contains("MCV"));
            Assert.IsTrue(output.Contains("Andi"));
            Assert.IsTrue(output.Contains("0101010101010101"));
            Assert.IsTrue(output.Contains("g/dL"));
            Assert.IsTrue(output.Contains("H")); // Leukosit tinggi
            Assert.IsTrue(output.Contains("L")); // MCV rendah
        }
    }
}
