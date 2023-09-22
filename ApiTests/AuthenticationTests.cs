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
    public class AuthenticationTests
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
        public async Task AuthenticateWithValidCredentials_ReturnsToken()
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
            var response = await authenticationService.AuthenticateAsync("P1IMX", "nelahi6642@4tmail.net", "DemoBDM1");

            // Assert
            Assert.IsNotNull(response.Token);
            Assert.IsFalse(string.IsNullOrEmpty(response.Token));
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
