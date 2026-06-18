using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class Domain
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
