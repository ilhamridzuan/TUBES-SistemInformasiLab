using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_Program.Models
{
    public class Pasien
    {
        public int NomorAntrian { get; set; }
        public string Nama { get; set; }

        public string NIK { get; set; }
        public string JenisKelamin { get; set; }
        public string JenisPasien { get; set; }
        public string Keluhan { get; set; }
        public DateTime WaktuDaftar { get; set; }

        public List<Pemeriksaan> Pemeriksaans { get; set; } = new();
    }
}

