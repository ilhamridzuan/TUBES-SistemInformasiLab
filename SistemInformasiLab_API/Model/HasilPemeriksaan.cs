using System;
using System.ComponentModel.DataAnnotations;

namespace SistemInformasiLab_API.Model
{
    public class HasilPemeriksaan
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaPasien { get; set; }

        [Required]
        [StringLength(100)]
        public string JenisPemeriksaan { get; set; }

        [Required]
        [StringLength(255)]
        public string Hasil { get; set; }

        [Required]
        public DateTime Tanggal { get; set; }
    }
}
