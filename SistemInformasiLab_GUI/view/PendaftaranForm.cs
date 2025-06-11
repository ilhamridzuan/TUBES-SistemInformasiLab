using Newtonsoft.Json;
using SistemInformasiLab_GUI.controller;
using SistemInformasiLab_GUI.model;
using SistemInformasiLab_GUI.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemInformasiLab_GUI.view
{
    public partial class PendaftaranForm : Form
    {
        private string suratRujukanPath = "";
        public PendaftaranForm()
        {
            InitializeComponent();
        }

        private void txtNama_TextChanged(object sender, EventArgs e) { }
        private void dateLahir_ValueChanged(object sender, EventArgs e) { }
        private void txtTelepon_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtAlamat_TextChanged(object sender, EventArgs e) { }

        private void btnPilihSurat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Pilih Surat Rujukan",
                Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                suratRujukanPath = dialog.FileName;
                lblSuratFile.Text = System.IO.Path.GetFileName(suratRujukanPath);
            }
        }


        private async void btnKirim_Click(object sender, EventArgs e)
        {
            var fields = new Dictionary<string, string>
    {
            { "Nama", txtNama.Text.Trim() },
            { "Telepon", txtTelepon.Text.Trim() },
            { "Email", txtEmail.Text.Trim() },
            { "Alamat", txtAlamat.Text.Trim() }
    };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Value))
                {
                    MessageBox.Show($"Field {field.Key} wajib diisi.");
                    return;
                }
            }

            var pasien = new PasienModel
            {
                Nama = fields["Nama"],
                Telepon = fields["Telepon"],
                Email = fields["Email"],
                Alamat = fields["Alamat"],
                TanggalLahir = dateLahir.Value,
                SuratRujukanPath = suratRujukanPath
            };

            try
            {
                var pasienTerdaftar = await PasienController.TambahPasienAsync(pasien);

                if (pasienTerdaftar != null)
                {
                    MessageBox.Show($"Pendaftaran berhasil!\nNomor Antrian: {pasienTerdaftar.NomorAntrian:D3}");
                    var antrianForm = new AntrianForm(pasienTerdaftar);
                    antrianForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Pendaftaran gagal.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mendaftar:\n" + ex.Message);
            }
        }
        private void btnBeranda_Click(object sender, EventArgs e)
        {
            this.Hide();
            var beranda = new DashboardPasien();
            beranda.Show();
        }

    }
}
