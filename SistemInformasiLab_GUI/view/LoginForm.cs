using SistemInformasiLab_GUI.controller;
using SistemInformasiLab_GUI.model;
using SistemInformasiLab_GUI.utils;
using System;
using System.Windows.Forms;

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

            if (!InputValidator.ValidateNotEmpty(username, "Username") ||
                !InputValidator.ValidateMinLength(password, "Password", 8))
                return;

            try
            {
                var result = await controller.LoginAsync(username, password);
                MessageBox.Show($"\n{result.Message}");

                if (!string.IsNullOrEmpty(result.Role))
                {
                    var dashboard = DashboardFactory.CreateDashboard(result.Role);
                    dashboard.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }

    public class DashboardFactory
    {
        public static Form CreateDashboard(string role)
        {
            switch (role.ToLower())
            {
                case "pasien":
                    return new DashboardPasien();
                case "dokter":
                    return new DashboardDokter();
                case "petugas":
                    return new DashboardPetugas();
                default:
                    throw new ArgumentException("Role tidak dikenali.");
            }
        }
    }
}