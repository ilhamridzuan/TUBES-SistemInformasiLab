namespace SistemInformasiLab_API.Model
{
    public enum UserRole { Pasien, Dokter, Petugas }
    public class User
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
