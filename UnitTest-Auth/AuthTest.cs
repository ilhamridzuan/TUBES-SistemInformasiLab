using Moq;
using Moq.Protected;
using SistemInformasiLab_Program.Models;
using SistemInformasiLab_Program.Services;
using System.Net;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTest_Auth
{
    [TestClass]
    public class AuthTest
    {
        private const string BaseUrl = "http://localhost:5031/";

        // Method ini membuat HttpClient palsu (mock) untuk menghindari pemanggilan API sungguhan
        private HttpClient CreateMockHttpClient(HttpResponseMessage response)
        {
            // Buat handler palsu untuk intercept request dan langsung kembalikan response yang kita tentukan
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",                          // method internal milik HttpClient yang dipanggil
                    ItExpr.IsAny<HttpRequestMessage>(),  // cocokkan semua request
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);                // kembalikan response yang diminta test

            // Buat HttpClient dari handler palsu ini
            return new HttpClient(handlerMock.Object)
            {
                BaseAddress = new System.Uri(BaseUrl)
            };
        }

        // Test 1: Login berhasil
        [TestMethod]
        public async Task LoginAsync_WithValidCredentials_ReturnsSuccess()
        {
            // Simulasikan response sukses dari server
            var expected = new LoginResponse { Message = "Login berhasil", Role = "Dokter" };

            var client = CreateMockHttpClient(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(expected)
            });

            var service = new HttpServiceForTest(client, BaseUrl);

            // Jalankan method login seperti biasa
            var result = await service.LoginAsync("user", "pass");

            // Pastikan hasilnya sesuai dengan yang diharapkan
            Assert.AreEqual(expected.Role, result.Role);
            Assert.AreEqual(expected.Message, result.Message);
        }

        // Test 2: Registrasi berhasil
        [TestMethod]
        public async Task RegisterAsync_WithValidData_ReturnsSuccess()
        {
            // Simulasi response sukses dari server
            var expected = new RegisterResponse { Message = "Registrasi berhasil" };

            var client = CreateMockHttpClient(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(expected)
            });

            var service = new HttpServiceForTest(client, BaseUrl);

            // Jalankan method registrasi
            var result = await service.RegisterAsync("Nama", "mail@mail.com", "user", "pass12345", "pasien");

            // Verifikasi hasilnya
            Assert.AreEqual(expected.Message, result.Message);
        }

        // Test 3: Login gagal (contoh login dengan password salah)
        [TestMethod]
        public async Task LoginAsync_WithUnauthorized_ReturnsErrorMessage()
        {
            // Simulasikan response gagal dari server (Unauthorized 401)
            var client = CreateMockHttpClient(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("Unauthorized")
            });

            var service = new HttpServiceForTest(client, BaseUrl);

            // Jalankan method login
            var result = await service.LoginAsync("wrong", "wrong");

            // Verifikasi bahwa Role null dan pesan mengandung "Login gagal"
            Assert.IsNull(result.Role);
            Assert.IsTrue(result.Message.Contains("Login gagal"));
        }
    }

    // Subclass HttpService untuk memungkinkan inject HttpClient palsu
    public class HttpServiceForTest : HttpService
    {
        public HttpServiceForTest(HttpClient client, string baseAddress)
            : base(baseAddress)
        {
            // Gunakan reflection untuk mengganti field private _client di HttpService
            typeof(HttpService)
                .GetField("_client", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(this, client);
        }
    }
}
