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
    public partial class DashboardDokter: Form
    {
        public DashboardDokter()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnLihatHasil_Click(object sender, EventArgs e)
        {
            this.Hide();
            LihatHasilFormDokter lihatHasil = new LihatHasilFormDokter();
            lihatHasil.Show();
        }
    }
}
