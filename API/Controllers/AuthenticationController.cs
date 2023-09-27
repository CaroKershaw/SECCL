using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using System.Security.Authentication;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using API.Data;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly DataContext _context;
        private readonly ITokenStorageService _tokenStorageService;
        private readonly ILogger<AuthenticationController> _logger;

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
                var authenticationResponse = await _authenticationService.AuthenticateAsync(request.FirmId, request.Id, request.Password);

                // // Assuming a fixed token expiration duration of 99 days
                // var tokenExpiry = DateTime.UtcNow.AddDays(99); // TODO: Change this to a more realistic token expiry period

                // // Store the access token in the database
                // var authToken = new AuthToken
                // {
                //     UserId = authenticationResponse.UserName, // Use UserName as UserId
                //     Token = authenticationResponse.Token,
                //     Expiry = tokenExpiry // Set token expiration
                // };

                // // Add the authToken to the database context
                // _context.AuthTokens.Add(authToken);

                // // Save changes to the database
                // await _context.SaveChangesAsync();

                // // Store the access token using the correct method signature
                // _tokenStorageService.StoreToken(authenticationResponse.UserName, authenticationResponse.Token);

                // Return the authentication response as JSON
                return Ok(authenticationResponse);
            }
            catch (AuthenticationException ex)
            {
                // Handle authentication-related exceptions
                return Unauthorized(new { Error = ex.Message });
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
