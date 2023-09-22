using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using API.Models;

namespace API.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _httpClient;

        public PortfolioService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Portfolio>> GetPortfoliosAsync(string firmId, string apiToken)
        {
            if (string.IsNullOrEmpty(firmId))
                throw new ArgumentNullException(nameof(firmId));
            if (string.IsNullOrEmpty(apiToken))
                throw new ArgumentNullException(nameof(apiToken));

            // Set the base URL and authorization headers
            _httpClient.BaseAddress = new Uri("{{apiRoute}}"); // Replace with your API route
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            try
            {
                var response = await _httpClient.GetAsync($"/portfolio/{firmId}/");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var portfolios = JsonSerializer.Deserialize<List<Portfolio>>(content);

                    return portfolios;
                }

                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("API request failed", ex);
            }
        }
    }
}
