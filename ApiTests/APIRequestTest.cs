using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Seccl.Test;

[TestClass]
public class ApiRequestTests
{
    // private HttpClient _httpClient;
    // private string _apiBaseUrl = "http://pfolio-api-staging.seccl.tech";
    // private string _firmId = "P1IMX";
    // private string _validToken = "your_valid_token";

    // [TestInitialize]
    // public void Initialize()
    // {
    //     _httpClient = new HttpClient();
    // }

    // [TestMethod]
    // public async Task GetPortfolios_ValidToken_ReturnsPortfolios()
    // {
    //     // Arrange
    //     var apiService = new ApiService(_httpClient);

    //     // Act
    //     var portfolios = await apiService.GetPortfoliosAsync(_apiBaseUrl, _firmId, _validToken);

    //     // Assert
    //     Assert.IsNotNull(portfolios);
    //     Assert.IsTrue(portfolios.Count > 0);
    // }
}
