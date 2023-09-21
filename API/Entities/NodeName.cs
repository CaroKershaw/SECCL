using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class NodeName
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}