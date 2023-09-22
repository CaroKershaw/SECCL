using System;

namespace API.Entities
{
    public class AuthToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } // User identifier
        public string Token { get; set; }  // Access token
        public DateTime Expiry { get; set; } // Token expiration date/time
    }
}
