using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class NewUser
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ADOrganizationalUnit? ADOrganizationalUnit { get; set; }
        public NewUserTemplate? NewUserTemplate { get; set; }
        public string? SupervisorEmail { get; set; }
        public AppUser? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string getSAMAccountName()
        {
            if (this.FirstName != null && this.LastName != null)
            {
                return $"{this.FirstName.Substring(0, 1)}.{this.LastName}".ToLower();
            }
            else
            {
                throw new Exception("First name and last name must be provided to generate SAM account name.");
            }
        }

        public string getEmailAddress()
        {
            return $"{this.getSAMAccountName()}@example.com";
        }
    }
}
