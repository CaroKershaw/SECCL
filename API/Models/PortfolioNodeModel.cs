using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PortfolioNodeModel
    {
        [Key]
        public int Id { get; set; }
        public string NodeId { get; set; }
        public string NodeName { get; set; }
    }
}
