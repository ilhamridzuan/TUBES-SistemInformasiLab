using SistemInformasiLab_Program.Models;

public class PasienService
{
    private List<Pasien> _pasienList;

    public PasienService(KonfigurasiService konfigurasiService)
    {
        _pasienList = DataDummy.GetAllPasien(konfigurasiService);
    }

    public Pasien? CariPasien(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentException("ID tidak boleh kosong");

        return _pasienList.FirstOrDefault(p => p.NIK.Equals(id, StringComparison.OrdinalIgnoreCase));
    }
}
