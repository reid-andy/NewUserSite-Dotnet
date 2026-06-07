using System.DirectoryServices;
using System.Runtime.Versioning;

namespace NewUserSite.Models
{
    public class ADSearcher
    {
        private int Id { get; }
        internal string? Username { get; set; }
        internal string? Password { get; set; }
        internal string? DomainControllerLocation { get; set; }
        internal string? DomainControllerRoot { get; set; } = null
        internal string? TemplateOU { get; set; }
        internal string? SearchBase;
        [SupportedOSPlatform("windows")]
        internal AuthenticationTypes AuthenticationType = AuthenticationTypes.Secure;

        ADSearcher(string? username, string? password, string? domainControllerLocation, string? templateOU)
        {
            this.Username = username;
            this.Password = password;
            this.DomainControllerLocation = domainControllerLocation;
            this.TemplateOU = templateOU;
            this.SearchBase = $"LDAP://{this.DomainControllerLocation}/{this.TemplateOU}";
        }
    }
}
