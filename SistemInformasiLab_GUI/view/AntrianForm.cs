using SistemInformasiLab_GUI.controller;
using SistemInformasiLab_GUI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemInformasiLab_GUI.view
{
    public partial class AntrianForm : Form
    {
        private readonly PasienModel pasienTerdaftar;

        public AntrianForm(PasienModel pasien)
        {
            InitializeComponent();
            pasienTerdaftar = pasien;
            this.Load += AntrianForm_Load;
        }

        private async void AntrianForm_Load(object sender, EventArgs e)
        {
            await TampilkanAntrianAsync();
        }

        private async Task TampilkanAntrianAsync()
        {
            var semuaPasien = await PasienController.GetAllPasienAsync();

            listViewAntrian.Items.Clear();

            if (semuaPasien == null || semuaPasien.Count == 0)
            {
                lblUrutanSaya.Text = "Urutan Anda: - dari 0 pasien";
                lblNomorSaya.Text = "-";
                return;
            }

            // Gunakan HashSet untuk mendeteksi pasien yang sudah ditampilkan
            var pasienYangSudahDitambahkan = new HashSet<string>();
            var daftarUnik = new List<PasienModel>();

            foreach (var pasien in semuaPasien.OrderBy(p => p.NomorAntrian))
            {
                // Buat kunci unik dari data pasien
                string kunciUnik = $"{pasien.Nama}-{pasien.TanggalLahir:yyyyMMdd}-{pasien.Telepon}";

                if (!pasienYangSudahDitambahkan.Contains(kunciUnik))
                {
                    pasienYangSudahDitambahkan.Add(kunciUnik);
                    daftarUnik.Add(pasien);
                }
            }

            int urutanSaya = 0;
            foreach (var (pasien, index) in daftarUnik.Select((p, i) => (p, i + 1)))
            {
                var item = new ListViewItem(index.ToString());
                item.SubItems.Add(pasien.Nama);
                listViewAntrian.Items.Add(item);

                if (pasien.Nama == pasienTerdaftar.Nama &&
                    pasien.TanggalLahir == pasienTerdaftar.TanggalLahir &&
                    pasien.Telepon == pasienTerdaftar.Telepon)
                {
                    urutanSaya = index;
                }
            }

            lblNomorSaya.Text = pasienTerdaftar.NomorAntrian.ToString("D3");
            lblUrutanSaya.Text = $"Urutan Anda: {urutanSaya} dari {daftarUnik.Count} pasien";
        }


        private void lblNomorSaya_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblNomorSaya.Text);
            MessageBox.Show("Nomor antrian Anda telah disalin.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
