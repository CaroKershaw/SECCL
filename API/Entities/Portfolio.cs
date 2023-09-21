using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        public string FirmId { get; set; }
        public string Name { get; set; }
        public ICollection<PortfolioNode> Nodes { get; set; } // Reference to PortfolioNode entities
        public ICollection<NodeName> NodeNames { get; set; } // Reference to NodeName entities
        public string Status { get; set; }
        public string Currency { get; set; }
        public decimal UninvestedCash { get; set; }
        public decimal Growth { get; set; }
        public decimal GrowthPercent { get; set; }
    }
}