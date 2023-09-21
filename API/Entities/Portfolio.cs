using System;
using System.Collections.Generic;

namespace API.Entities;

public class Portfolio
{
    public string Id { get; set; }
    public string FirmId { get; set; }
    public string Name { get; set; }
    public List<string> NodeIds { get; set; }
    public List<string> NodeNames { get; set; }
    public string Status { get; set; }
    public string Currency { get; set; }
    public decimal UninvestedCash { get; set; }
    public decimal Growth { get; set; }
    public decimal GrowthPercent { get; set; }
}
