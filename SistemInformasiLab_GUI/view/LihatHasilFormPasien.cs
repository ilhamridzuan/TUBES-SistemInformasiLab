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
    public partial class LihatHasilFormPasien: Form
    {
        private readonly HasilPemeriksaanController _controller;
        public LihatHasilFormPasien()
        {
            InitializeComponent();
            _controller = new HasilPemeriksaanController();
        }

        private async void LihatHasilFormPasien_Load(object sender, EventArgs e)
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
            DashboardPasien dashboard = new DashboardPasien();
            dashboard.Show();
        }
    }
}
