using Microsoft.AspNetCore.Mvc;
using SistemInformasiLab_API.Model;
using SistemInformasiLab_API.Services;

namespace SistemInformasiLab_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static readonly AuthService authService = new AuthService();

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            try
            {
                authService.Register(request.Fullname, request.Email,request.Username, request.Password, request.Role);
                return Ok(new { message = "Registrasi berhasil" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = authService.Login(request.Username, request.Password);
            if (user != null)
                return Ok(new { message = "Login berhasil", role = user.Role.ToString() });
            else
                return Unauthorized(new { message = "Username atau password salah" });
        }

        [HttpGet("me")]
        public IActionResult GetCurrentUser([FromQuery] string username)
        {
            var user = authService.GetUserByUsername(username);
            if (user == null)
                return NotFound("User tidak ditemukan.");

            return Ok(user);
        }
    }
}
