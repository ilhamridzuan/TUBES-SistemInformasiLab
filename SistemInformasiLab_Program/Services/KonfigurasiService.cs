using System.Text.Json;
using SistemLaboratorium.Configuration;

public class KonfigurasiService
{
    private readonly Dictionary<string, (double, double)> _batasNormalMap;

    public KonfigurasiService()
    {
        var json = File.ReadAllText("konfigurasi.json");
        var konfigurasiList = JsonSerializer.Deserialize<List<KonfigurasiPemeriksaan>>(json);
        _batasNormalMap = konfigurasiList.ToDictionary(k => k.Nama, k => (k.BatasBawah, k.BatasAtas));
    }

    public (double, double) AmbilBatasNormal(string namaPemeriksaan)
    {
        if (_batasNormalMap.TryGetValue(namaPemeriksaan, out var batas))
        {
            return batas;
        }

        throw new KeyNotFoundException($"Konfigurasi untuk '{namaPemeriksaan}' tidak ditemukan.");
    }
}
