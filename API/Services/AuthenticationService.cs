using System;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiBaseUrl = "https://pfolio-api-staging.seccl.tech"; //API base URL
        }

        public async Task<AuthenticationResponseModel> AuthenticateAsync(AuthenticationRequestModel request)
        {
            try
            {
                // Serialize the request model to JSON
                var requestJson = JsonSerializer.Serialize(request);

                // Create a new HTTP request message
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_apiBaseUrl}/authenticate"),
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
                };

                // Send the request to the API
                var response = await _httpClient.SendAsync(httpRequest);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response to the AuthenticationResponseModel
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponseModel>(responseJson);

                    return authenticationResponse;
                }
                else
                {
                    // Handle API error response (e.g., invalid credentials)
                    // You can customize error handling based on the HTTP status code
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new AuthenticationException("Invalid credentials. Please check your Firm ID, ID, and Password.");
                    }
                    else
                    {
                        throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request-related errors
                throw new AuthenticationException($"API request failed: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Handle JSON serialization/deserialization errors
                throw new AuthenticationException($"JSON processing error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                throw new AuthenticationException($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
