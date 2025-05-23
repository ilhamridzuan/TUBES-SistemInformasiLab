using SistemInformasiLab_Program.Models;

public static class DataDummy
{
    public static List<Pasien> GetAllPasien(KonfigurasiService konfigurasiService)
    {
        return new List<Pasien>
        {
            new Pasien
            {
                NIK = "0101010101010101",
                Nama = "Andi",
                Pemeriksaans = new List<Pemeriksaan>
                {
                    new Pemeriksaan
                    {
                        Nama = "Hemoglobin",
                        Hasil = 12,
                        Satuan = "g/dL",
                        NilaiNormal = konfigurasiService.AmbilBatasNormal("Hemoglobin")
                    },
                    new Pemeriksaan
                    {
                        Nama = "Leukosit",
                        Hasil = 14.6,
                        Satuan = "10^3/uL",
                        NilaiNormal = konfigurasiService.AmbilBatasNormal("Leukosit")
                    },
                    new Pemeriksaan
                    {
                        Nama = "MCV",
                        Hasil = 71.4,
                        Satuan = "fL",
                        NilaiNormal = konfigurasiService.AmbilBatasNormal("MCV")
                    }
                }
            }
        };
    }
}
