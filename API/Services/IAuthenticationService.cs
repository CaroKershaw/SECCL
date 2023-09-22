using System;
using System.Threading.Tasks;
using API.Models;
using API.Services;

namespace API.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseModel> AuthenticateAsync(AuthenticationRequestModel request);
    }
}
