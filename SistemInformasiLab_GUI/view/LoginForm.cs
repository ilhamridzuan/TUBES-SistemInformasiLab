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
using SistemInformasiLab_GUI.utils;


namespace SistemInformasiLab_GUI.view
{
    public partial class LoginForm : Form
    {
        private readonly AuthController controller;
        public LoginForm()
        {
            controller = new AuthController("http://localhost:5031/");
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = InputUsername.Text.Trim();
            string password = InputPassword.Text.Trim();
            if (!InputValidator.ValidateNotEmpty(username, "Username")) return;
            if (!InputValidator.ValidateMinLength(password, "Password", 8)) return;

            var result = await controller.LoginAsync(username, password);
            MessageBox.Show($"\n{result.Message}");
            if (result.Role != null)
            {
                if (result.Role == "Pasien")
                {
                    /*DashboardPasien dashboardPasien = new DashboardPasien();
                    dashboardPasien.Show();
                    this.Hide();*/
                }
                else if (result.Role == "Dokter")
                {
                    /*DashboardDokter dashboardDokter = new DashboardDokter();
                    dashboardDokter.Show();
                    this.Hide();*/
                }
                else if (result.Role == "Petugas")
                {
                    /*DashboardPetugas dashboardPetugas = new DashboardPetugas();
                    dashboardPetugas.Show();
                    this.Hide();*/
                }
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

            this.Hide();
        }
    }
}
