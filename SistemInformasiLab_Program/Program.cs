using SistemInformasiLab_Program.Controllers;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        AuthController controller = new AuthController();
        await controller.ShowMenuAsync(); // Menampilkan menu login/registrasi
    }
}