using System.ComponentModel.DataAnnotations;


namespace NewUserSite.Models
{
    public class ApplicationPreferences
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string OrganizationalUnit { get; set; } = "Department";
        [MaxLength(100)]
        public string Template { get; set; } = "Job Title";
        public bool AutoApproveNewUserRequests { get; set; }

    }
}
