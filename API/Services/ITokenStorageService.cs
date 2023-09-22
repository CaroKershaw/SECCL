using System.Threading.Tasks;

namespace API.Services
{
    public interface ITokenStorageService
    {
        void StoreToken(string userId, string accessToken);
        string GetToken(string userId);
    }
}
