using System.Collections.Generic;

namespace API.Models
{
    public class AuthenticationResponseModel
    {
        public string Token { get; set; } // Add Token property
        public string UserName { get; set; }
        public List<ScopeModel> Scopes { get; set; }
        public List<string> Services { get; set; }
    }
}
