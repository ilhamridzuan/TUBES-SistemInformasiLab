using System;
using System.Collections.Generic;
using SistemInformasiLab_API.Model;

namespace SistemInformasiLab_API.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();
        private Dictionary<string, UserRole> allowedRoles = new Dictionary<string, UserRole>
        {
            {"pasien", UserRole.Pasien },
            {"dokter", UserRole.Dokter },
            {"petugas", UserRole.Petugas }
        };

        public void Register(string fullname, string email, string username, string password, string roleName)
        {
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Field tidak boleh kosong.");

            if (username.Length < 4 || password.Length < 6)
                throw new ArgumentException("Username minimal 4 karakter, password minimal 6.");

            if (!allowedRoles.ContainsKey(roleName.ToLower()))
                throw new ArgumentException("Role tidak valid.");

            if (users.Exists(u => u.Username == username))
                throw new InvalidOperationException("Username sudah digunakan.");

            users.Add(new User
            {
                Fullname = fullname,
                Email = email,
                Username = username,
                Password = HashPassword(password),
                Role = allowedRoles[roleName.ToLower()]
            });
        }
        enum State { Start, Validating, Authenticating, Success, Failed }
        public User Login (string username, string password)
        {
            State state = State.Start;
            try
            {
                state = State.Validating;
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Input tidak boleh kosong.");

                state = State.Authenticating;
                var user = users.Find(u => u.Username == username);
                if (user == null || user.Password != HashPassword(password))
                    throw new UnauthorizedAccessException("Login gagal.");

                state = State.Success;
                return user;

            }
            catch
            {
                state = State.Failed;
                return null;
            }
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public User? GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
    }
}
