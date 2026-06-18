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
        public Domain? Domain { get; set; }
        public string? SupervisorEmail { get; set; }
        // Todo: Implement real auth
        //public AppUser? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string getSAMAccountName()
        {
            if (this.FirstName != null && this.LastName != null)
            {
                return $"{this.FirstName}.{this.LastName}".ToLower();
            }
            else
            {
                throw new Exception("First name and last name must be provided to generate SAM account name.");
            }
        }

        public string getDisplayName()
        {
            if (this.FirstName != null && this.LastName != null)
            {
                return $"{this.FirstName} {this.LastName}";
            }
            else
            {
                throw new Exception("First name and last name must be provided to generate display name.");
            }
        }

        public string getDistinguishedName()
        {
            if (this.ADOrganizationalUnit != null)
            {
                return $"CN={this.getSAMAccountName()},{this.ADOrganizationalUnit.ADDistinguishedName}";
            }
            else
            {
                throw new Exception("Organizational unit must be provided to generate distinguished name.");
            }
        }

        public string getEmailAddress()
        {
            return $"{this.getSAMAccountName()}@{this.Domain}";
        }
    }
}
