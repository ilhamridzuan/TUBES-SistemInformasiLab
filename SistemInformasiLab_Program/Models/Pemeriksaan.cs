public class Pemeriksaan
{
    public string Nama { get; set; }
    public double? Hasil { get; set; }
    public string Satuan { get; set; }
    public (double Bawah, double Atas) NilaiNormal { get; set; }

    public string Keterangan
    {
        get
        {
            if (Hasil == null) return "-";
            if (Hasil < NilaiNormal.Bawah) return "L";
            if (Hasil > NilaiNormal.Atas) return "H";
            return "";
        }
    }

    public string NilaiNormalFormatted => $"{NilaiNormal.Bawah} - {NilaiNormal.Atas}";
}
