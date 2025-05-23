using System;
using System.Net.Mail;

namespace SistemInformasiLab_Program.Utils
{
    public static class InputValidator
    {
        public static void ValidateNotEmpty(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"{fieldName} tidak boleh kosong.");
        }

        public static void ValidateEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException("Format email tidak valid.");
            }
        }

        public static void ValidateMinLength(string input, string fieldName, int minLength)
        {
            if (input.Length < minLength)
                throw new ArgumentException($"{fieldName} minimal {minLength} karakter.");
        }
    }
}
