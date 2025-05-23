using SistemInformasiLab_Program.Models;

public class PemeriksaanService
{
    public void TampilkanHasil(Pasien pasien)
    {
        Console.WriteLine($"\nPemeriksaan untuk pasien: {pasien.Nama} ({pasien.NIK})");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"{"Pemeriksaan",-20} {"Hasil",6} {"Satuan",8} {"Normal",15} {"Ket"}");
        Console.WriteLine("---------------------------------------------------------");

        foreach (var p in pasien.Pemeriksaans)
        {
            var hasil = p.Hasil.HasValue ? p.Hasil.Value.ToString("F1") : "-";
            Console.WriteLine($"{p.Nama,-20} {hasil,6} {p.Satuan,8} {p.NilaiNormalFormatted,15} {p.Keterangan}");
        }
    }
}
