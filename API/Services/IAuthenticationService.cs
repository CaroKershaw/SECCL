using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseModel> AuthenticateAsync(string firmId, string userId, string password);
    }
}
