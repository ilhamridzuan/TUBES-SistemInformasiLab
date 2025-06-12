using SistemInformasiLab_GUI.controller;
using SistemInformasiLab_GUI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemInformasiLab_GUI.view
{
    public partial class PengelolaanDataForm: Form
    {
        // Deklarasi controller untuk menghubungkan ke API
        private readonly HasilPemeriksaanController controller = new HasilPemeriksaanController();
        public PengelolaanDataForm()
        {
            InitializeComponent();  // Inisialisasi komponen form
            LoadData(); // Load data saat form pertama kali dibuka
        }

        // Method untuk memuat semua data hasil pemeriksaan dari API
        private async void LoadData()
        {
            try
            {
                var data = await controller.GetAll(); // Ambil semua data dari API
                dataGridView1.DataSource = data;      // Tampilkan data di tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        // Mengisi data input saat user klik baris di tabel
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                // Ambil dan tampilkan nilai dari tabel ke form input
                txtId.Text = row.Cells["Id"].Value?.ToString();
                txtNama.Text = row.Cells["NamaPasien"].Value?.ToString();
                txtJenis.Text = row.Cells["JenisPemeriksaan"].Value?.ToString();
                txtHasil.Text = row.Cells["Hasil"].Value?.ToString();

                // Amankan parsing tanggal
                if (DateTime.TryParse(row.Cells["Tanggal"].Value?.ToString(), out var tanggal))
                {
                    dtpTanggal.Value = tanggal;
                }
            }
        }

        // Tombol untuk menambahkan data baru
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("ID tidak boleh kosong.");
                return;
            }

            // Cegah duplikasi berdasarkan ID di DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Id"].Value?.ToString() == txtId.Text)
                {
                    MessageBox.Show("ID sudah digunakan.");
                    return;
                }
            }

            var hasil = new HasilPemeriksaan
            {
                Id = txtId.Text.Trim(),
                NamaPasien = txtNama.Text.Trim(),
                JenisPemeriksaan = txtJenis.Text.Trim(),
                Hasil = txtHasil.Text.Trim(),
                Tanggal = dtpTanggal.Value
            };

            if (await controller.Insert(hasil))
            {
                MessageBox.Show("Data berhasil ditambahkan.");
                LoadData();
                ClearForm(); // Bersihkan isian
            }
            else
            {
                MessageBox.Show("Gagal menambahkan data.");
            }
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtNama.Clear();
            txtJenis.Clear();
            txtHasil.Clear();
            dtpTanggal.Value = DateTime.Now;
        }

        // Tombol untuk mengupdate data
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var hasil = new HasilPemeriksaan
            {
                Id = txtId.Text,
                NamaPasien = txtNama.Text,
                JenisPemeriksaan = txtJenis.Text,
                Hasil = txtHasil.Text,
                Tanggal = dtpTanggal.Value
            };

            if (await controller.Update(hasil.Id, hasil))
            {
                MessageBox.Show("Data berhasil diupdate.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal mengupdate data.");
            }
        }

        // Tombol untuk menghapus data
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = txtId.Text.Trim(); // Trim whitespace
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("ID tidak boleh kosong untuk menghapus.");
                return;
            }

            try
            {
                if (await controller.Delete(id))
                {
                    MessageBox.Show("Data berhasil dihapus.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menghapus data: " + ex.Message);
            }
        }

        // Validasi input form, bagian dari secure coding
        private bool ValidateFormData()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtJenis.Text) ||
                string.IsNullOrWhiteSpace(txtHasil.Text))
            {
                MessageBox.Show("Semua field harus diisi.");
                return false;
            }
            return true;
        }

        // Ekstraksi data dari form ke model. Bagian dari clean code: DRY
        private HasilPemeriksaan GetFormData()
        {
            return new HasilPemeriksaan
            {
                Id = txtId.Text.Trim(),
                NamaPasien = txtNama.Text.Trim(),
                JenisPemeriksaan = txtJenis.Text.Trim(),
                Hasil = txtHasil.Text.Trim(),
                Tanggal = dtpTanggal.Value
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPetugas dashboard = new DashboardPetugas();
            dashboard.Show();
        }
    }
}