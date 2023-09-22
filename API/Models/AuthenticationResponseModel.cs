using System.Collections.Generic;

namespace API.Models
{
    public class AuthenticationResponseModel
    {
        public DataModel Data { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public List<ScopeModel> Scopes { get; set; }
        public List<string> Services { get; set; }
    }
}
