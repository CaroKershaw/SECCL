using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using System.Security.Authentication;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using API.Data; // Import the necessary namespace for logging

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly DataContext _context; // Add DataContext for database access
        private readonly ITokenStorageService _tokenStorageService; // Add token storage service
        private readonly ILogger<AuthenticationController> _logger; // Add a logger

        public AuthenticationController(
            IAuthenticationService authenticationService,
            DataContext context,
            ITokenStorageService tokenStorageService,
            ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokenStorageService = tokenStorageService ?? throw new ArgumentNullException(nameof(tokenStorageService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequestModel request)
        {
            try
            {
                // Call the authentication service to validate the credentials
                var authenticationResponse = await _authenticationService.AuthenticateAsync(request);

                // Store the access token in the database
                var authToken = new AuthToken
                {
                    Token = authenticationResponse.Token,
                    Expiry = DateTime.UtcNow.AddHours(1) // Set token expiration (adjust as needed)
                };

                _context.AuthTokens.Add(authToken);
                await _context.SaveChangesAsync();

                // Store the access token using the correct method signature
                _tokenStorageService.StoreToken(authenticationResponse.UserName, authenticationResponse.Token);

                // Return the authentication response as JSON
                return Ok(authenticationResponse);
            }
            catch (AuthenticationException ex)
            {
                // Handle authentication-related exceptions
                return Unauthorized(new { Error = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                // Handle database update errors
                _logger.LogError($"Database update error: {ex.Message}");
                return StatusCode(500, new { Error = "An error occurred while storing the access token." });
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
