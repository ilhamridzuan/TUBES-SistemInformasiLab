using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemInformasiLab_GUI.utils
{
    class InputValidator
    {
        public static bool ValidateNotEmpty(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show($"{fieldName} tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool ValidateEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                MessageBox.Show("Format email tidak valid.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static bool ValidateMinLength(string input, string fieldName, int minLength)
        {
            if (input.Length < minLength)
            {
                MessageBox.Show($"{fieldName} minimal {minLength} karakter.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool ValidateComboBoxSelected(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show($"{fieldName} harus dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
