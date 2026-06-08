using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using System.Runtime.Versioning;

namespace NewUserSite.Models
{
    public class ADSearcher
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DomainControllerLocation { get; set; }
        public string? DomainControllerRoot { get; set; }
        public string? TemplateOU { get; set; }
        [SupportedOSPlatform("windows")]
        public AuthenticationTypes AuthenticationType = AuthenticationTypes.Secure;

        public string? getSearchBase() {
        return $"LDAP://{this.DomainControllerLocation}/{this.TemplateOU}";
        }
    }
}
