﻿using System;
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
    public partial class DashboardPetugas: Form
    {
        public DashboardPetugas()
        {
            InitializeComponent();
        }

        private void btnKelola_Click(object sender, EventArgs e)
        {
            this.Hide();
            PengelolaanDataForm kelolaData = new PengelolaanDataForm();
            kelolaData.Show();
        }

        private void btnLihatHasil_Click(object sender, EventArgs e)
        {
            this.Hide();
            LihatHasilForm lihatHasil = new LihatHasilForm();
            lihatHasil.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
