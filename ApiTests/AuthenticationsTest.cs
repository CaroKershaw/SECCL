

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Seccl.Test;

[TestClass]
public class AuthenticationTests
{
    // private HttpClient _httpClient;
    // private string _apiBaseUrl = "http://pfolio-api-staging.seccl.tech";
    // private string _firmId = "P1IMX";
    // private string _userId = "nelahi6642@4tmail.net";
    // private string _password = "DemoBDM1";

    // [TestInitialize]
    // public void Initialize()
    // {
    //     _httpClient = new HttpClient();
    // }

    // [TestMethod]
    // public async Task AuthenticateWithValidCredentials_ReturnsToken()
    // {
    //     // Arrange
    //     var authenticationService = new AuthenticationService(_httpClient);

    //     // Act
    //     var token = await authenticationService.AuthenticateAsync(_apiBaseUrl, _firmId, _userId, _password);

    //     // Assert
    //     Assert.IsNotNull(token);
    //     Assert.IsFalse(string.IsNullOrEmpty(token));
    // }

    // [TestMethod]
    // public async Task AuthenticateWithInvalidCredentials_ReturnsNullToken()
    // {
    //     // Arrange
    //     var authenticationService = new AuthenticationService(_httpClient);

    //     // Act
    //     var token = await authenticationService.AuthenticateAsync(_apiBaseUrl, _firmId, "invalid_user", "invalid_password");

    //     // Assert
    //     Assert.IsNull(token);
    // }
}