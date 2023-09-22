using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API.Services;
using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Seccl.Test
{
    [TestClass]
    public class AuthenticationTests_InvalidCredentials
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private string _apiBaseUrl;

        [TestInitialize]
        public void Initialize()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _httpClient = new HttpClient();
            _apiBaseUrl = _configuration["ApiBaseUrl"];
        }

        [TestMethod]
        public async Task AuthenticateWithInvalidCredentials_ReturnsNullToken()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddHttpClient<AuthenticationService>((client) =>
            {
                client.BaseAddress = new Uri(_apiBaseUrl);
            });

            var serviceProvider = services.BuildServiceProvider();
            var authenticationService = serviceProvider.GetRequiredService<AuthenticationService>();

            // Act
            var response = await authenticationService.AuthenticateAsync("P1IMX", "invalid_user", "invalid_password");

            // Assert
            Assert.IsNull(response.Token);
        }
    }
}
