using System.ComponentModel.DataAnnotations;

public class PortfolioNode
{
    [Key]
    public int Id { get; set; }
    public string NodeId { get; set; }
    public string NodeName { get; set; }
}