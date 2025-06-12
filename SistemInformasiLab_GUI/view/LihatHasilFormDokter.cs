using SistemInformasiLab_GUI.controller;
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
    public partial class LihatHasilFormDokter: Form
    {
        private readonly HasilPemeriksaanController _controller;
        public LihatHasilFormDokter()
        {
            InitializeComponent();
            _controller = new HasilPemeriksaanController();
        }

        private async void LihatHasilFormDokter_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                var data = await _controller.GetAll();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnBeranda_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DashboardDokter dashboard = new DashboardDokter();
            dashboard.Show();
        }
    }
}
