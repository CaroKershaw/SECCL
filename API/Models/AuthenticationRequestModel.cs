using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AuthenticationRequestModel
    {
        public string FirmId { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
