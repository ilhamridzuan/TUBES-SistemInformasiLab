using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemInformasiLab_GUI.model
{
    public class PasienModel
    {
        public string Nama { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string Telepon { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string SuratRujukanPath { get; set; }
        public int NomorAntrian { get; set; }
        public DateTime TanggalDaftar { get; internal set; }
    }
}
