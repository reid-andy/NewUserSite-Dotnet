using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class NewUserTemplate
    {
        [Key]
        public int Id { get; set; }
        public string? TemplateName { get; set; }
        public string? TemplateSAMAccountName { get; set; }
        public List<ADOrganizationalUnit> ADOrganizationalUnits { get; } = [];
    }
}
