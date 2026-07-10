using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using System.Runtime.Versioning;


namespace NewUserSite.Models
{
    public class ApplicationPreferences
    {
        [Key]
        public int Id { get; set; }
        public string OrganizationalUnit { get; set; } = "Department";
        public string Template { get; set; } = "Job Title";

    }
}
