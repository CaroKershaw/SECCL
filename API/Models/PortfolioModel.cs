using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PortfolioModel
    {
        [Key]
        public int Id { get; set; }
        public string FirmId { get; set; }
        public string Name { get; set; }
        public ICollection<PortfolioNodeModel> Nodes { get; set; }
        public ICollection<NodeNameModel> NodeNames { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public decimal UninvestedCash { get; set; }
        public decimal Growth { get; set; }
        public decimal GrowthPercent { get; set; }
    }
}