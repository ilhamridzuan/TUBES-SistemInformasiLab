using System;
using System.Collections.Generic;
using SistemInformasiLab_API.Model;
using SistemInformasiLab_Program.Utils;

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

        /// <summary>
        /// Registers a new user.
        /// Preconditions:
        /// - fullname, email, username, password, and roleName must not be null or empty
        /// - email must be valid format
        /// - username ≥ 4 chars
        /// - password ≥ 8 chars
        /// - roleName must be in allowedRoles
        /// - username must not already exist
        /// Postconditions:
        /// - User added to users list with hashed password and correct role
        /// </summary>
        public void Register(string fullname, string email, string username, string password, string roleName)
        {
            // === PRECONDITIONS ===
            InputValidator.ValidateNotEmpty(fullname, nameof(fullname));
            InputValidator.ValidateNotEmpty(email, nameof(email));
            InputValidator.ValidateEmail(email);
            InputValidator.ValidateNotEmpty(username, nameof(username));
            InputValidator.ValidateMinLength(username, nameof(username), 4);
            InputValidator.ValidateNotEmpty(password, nameof(password));
            InputValidator.ValidateMinLength(password, nameof(password), 8);
            InputValidator.ValidateNotEmpty(roleName, nameof(roleName));

            string roleKey = roleName.ToLower().Trim();
            if (!allowedRoles.ContainsKey(roleKey))
                throw new ArgumentException("Role tidak valid.");

            if (users.Any(u => u.Username == username))
                throw new InvalidOperationException("Username sudah digunakan.");

            // === POSTCONDITION: User ditambahkan ===
            users.Add(new User
            {
                Fullname = fullname.Trim(),
                Email = email.Trim(),
                Username = username.Trim(),
                Password = HashPassword(password),
                Role = allowedRoles[roleKey]
            });
        }

        /// <summary>
        /// Attempts login for a user.
        /// Preconditions:
        /// - username and password must not be null or empty
        /// Postconditions:
        /// - Returns user if authenticated; otherwise null
        /// </summary>
        public User Login(string username, string password)
        {
            // === PRECONDITIONS ===
            InputValidator.ValidateNotEmpty(username, nameof(username));
            InputValidator.ValidateNotEmpty(password, nameof(password));

            var user = users.FirstOrDefault(u => u.Username == username.Trim());
            if (user == null)
                return null;

            if (user.Password != HashPassword(password))
                return null;

            // === POSTCONDITION: User dikembalikan ===
            return user;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public User? GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username?.Trim());
        }
    }
}
