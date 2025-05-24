using Xunit;
using SistemInformasiLab_Program.Models;
using System;

public class PasienServiceTests
{
    private readonly PasienService _pasienService;

    public PasienServiceTests()
    {
        var konfigurasiService = new KonfigurasiService();
        _pasienService = new PasienService(konfigurasiService);
    }

    [Fact]
    public void CariPasien_DenganIdValid_MengembalikanPasien()
    {
        var pasien = _pasienService.CariPasien("0101010101010101");

        Assert.NotNull(pasien);
        Assert.Equal("Andi", pasien.Nama);
        Assert.NotEmpty(pasien.Pemeriksaans);
    }

    [Fact]
    public void CariPasien_DenganIdTidakDikenal_MengembalikanNull()
    {
        var pasien = _pasienService.CariPasien("9999999999999999");

        Assert.Null(pasien);
    }

    [Fact]
    public void CariPasien_DenganIdKosong_ThrowArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _pasienService.CariPasien(""));
        Assert.Equal("ID tidak boleh kosong", ex.Message);
    }
}
