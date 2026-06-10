using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class ADOrganizationalUnit
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ADDistinguishedName { get; set; }
        public bool IsChecked { get; set; }
        public List<NewUserTemplate> NewUserTemplates { get; } = [];
    }
}
