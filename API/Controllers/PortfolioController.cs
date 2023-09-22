using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly ITokenStorageService _tokenStorageService;
        private readonly ILogger<PortfolioController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://pfolio-api-staging.seccl.tech"; // API base URL

        public PortfolioController(
            ITokenStorageService tokenStorageService,
            ILogger<PortfolioController> logger,
            HttpClient httpClient)
        {
            _tokenStorageService = tokenStorageService ?? throw new ArgumentNullException(nameof(tokenStorageService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListPortfoliosAsync()
        {
            try
            {
                // Get the access token from the token storage service based on the user's identity.
                var userId = User.Identity.Name;
                var accessToken = _tokenStorageService.GetToken(userId);

                // Check if the access token is available and not expired
                if (string.IsNullOrEmpty(accessToken))
                {
                    return Unauthorized(new { Error = "Access token is missing or expired. Please reauthenticate." });
                }

                // Create an HTTP request to fetch portfolios
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_apiBaseUrl}/portfolio/{userId}"),
                };

                // Set the authorization header with the access token
                request.Headers.Add("Authorization", $"Bearer {accessToken}");

                // Send the request to the SECCL API
                var response = await _httpClient.SendAsync(request);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response to the desired model
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var portfolios = JsonSerializer.Deserialize<List<PortfolioModel>>(responseJson);

                    // Return the portfolios as JSON
                    return Ok(portfolios);
                }
                else
                {
                    // Handle API error response (e.g., unauthorized, not found, etc.)
                    // TODO: Customize error handling based on the HTTP status code
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized(new { Error = "Unauthorized access to SECCL API." });
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return NotFound(new { Error = "Portfolios not found." });
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, new { Error = $"API request failed with status code {response.StatusCode}" });
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                _logger.LogError($"An unexpected error occurred: {ex.Message}");
                return StatusCode(500, new { Error = $"An unexpected error occurred: {ex.Message}" });
            }
        }
    }
}
