using System;
using System.Collections.Generic;

namespace API.Services
{
    public class TokenStorageService : ITokenStorageService
    {
        private readonly Dictionary<string, string> _tokenStorage = new Dictionary<string, string>();

        public void StoreToken(string userId, string accessToken)
        {
            // Store the access token in memory
            _tokenStorage[userId] = accessToken;
        }

        public string GetToken(string userId)
        {
            if (_tokenStorage.TryGetValue(userId, out var accessToken))
            {
                return accessToken;
            }
            return null; // Token not found
        }
    }
}
