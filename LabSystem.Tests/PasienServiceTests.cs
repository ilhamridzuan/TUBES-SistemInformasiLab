public class PasienServiceTests
{
    private PasienService BuatPasienServiceUntukTest()
    {
        // Pastikan file konfigurasi_test.json tersedia di direktori output (bin)
        var path = Path.Combine(AppContext.BaseDirectory, "konfigurasi_test.json");
        var konfigurasiService = new KonfigurasiService(path);
        return new PasienService(konfigurasiService);
    }

    [Fact]
    public void CariPasien_IdValid_ReturnsPasien()
    {
        var service = BuatPasienServiceUntukTest();
        var pasien = service.CariPasien("0101010101010101");

        Assert.NotNull(pasien);
        Assert.Equal("Andi", pasien?.Nama);
    }

    [Fact]
    public void CariPasien_IdTidakDitemukan_ReturnsNull()
    {
        var service = BuatPasienServiceUntukTest();
        var pasien = service.CariPasien("9999999999999999");

        Assert.Null(pasien);
    }

    [Fact]
    public void CariPasien_IdKosong_ThrowArgumentException()
    {
        var service = BuatPasienServiceUntukTest();

        var ex = Assert.Throws<ArgumentException>(() => service.CariPasien(""));
        Assert.Equal("ID tidak boleh kosong", ex.Message);
    }
}
