using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_GUI.model
{
    class HasilPemeriksaan
    {
        public string Id { get; set; }
        public string NamaPasien { get; set; }
        public string JenisPemeriksaan { get; set; }
        public string Hasil { get; set; }
        public DateTime Tanggal { get; set; }
    }
}
