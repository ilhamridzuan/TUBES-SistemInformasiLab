using Xunit;
using SistemInformasiLab_Program.Models;

public class PemeriksaanTests
{
    [Fact]
    public void Keterangan_HasilLebihRendah_ReturnsL()
    {
        var p = new Pemeriksaan { Hasil = 10, NilaiNormal = (11.7, 15.5) };
        Assert.Equal("L", p.Keterangan);
    }

    [Fact]
    public void Keterangan_HasilLebihTinggi_ReturnsH()
    {
        var p = new Pemeriksaan { Hasil = 16, NilaiNormal = (11.7, 15.5) };
        Assert.Equal("H", p.Keterangan);
    }

    [Fact]
    public void Keterangan_HasilNormal_ReturnsEmptyString()
    {
        var p = new Pemeriksaan { Hasil = 13, NilaiNormal = (11.7, 15.5) };
        Assert.Equal("", p.Keterangan);
    }

    [Fact]
    public void Keterangan_HasilNull_ReturnsStrip()
    {
        var p = new Pemeriksaan { Hasil = null, NilaiNormal = (11.7, 15.5) };
        Assert.Equal("-", p.Keterangan);
    }
}
