using SistemInformasiLab_GUI.controller;
using SistemInformasiLab_GUI.model;
using SistemInformasiLab_GUI.utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemInformasiLab_GUI.view
{
    public partial class RegisterForm : Form
    {
        private readonly AuthController controller;
        public RegisterForm()
        {
            controller = new AuthController("http://localhost:5031/");
            InitializeComponent();

            var roles = new List<RoleItem>
            {
                new RoleItem { Display = "Pasien", Value = "pasien" },
                new RoleItem { Display = "Dokter", Value = "dokter" },
                new RoleItem { Display = "Petugas", Value = "petugas" }
            };

            comboBoxRole.DataSource = roles;
            comboBoxRole.DisplayMember = "Display";
            comboBoxRole.ValueMember = "Value";
        }

        private async void BtnRegistrasi_Click(object sender, EventArgs e)
        {
            string fullname = inputFullname.Text.Trim();
            if (!InputValidator.ValidateNotEmpty(fullname, "Fullname")) return;
            string email = inputEmail.Text.Trim();
            if (!InputValidator.ValidateEmail(email)) return;
            string username = inputUsername.Text.Trim();
            if (!InputValidator.ValidateNotEmpty(username, "Username")) return;
            string password = inputPassword.Text.Trim();
            if (!InputValidator.ValidateMinLength(password, "Password", 8)) return;
            string role = comboBoxRole.SelectedValue?.ToString() ?? "";

            var result = await controller.RegisterAsync(fullname, email, username, password, role);
            MessageBox.Show($"\n{result.Message}");

            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
