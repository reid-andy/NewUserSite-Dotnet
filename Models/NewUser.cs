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
        public string? CreatedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public string GetSAMAccountName()
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

        public string GetDisplayName()
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

        public string GetDistinguishedName()
        {
            if (this.ADOrganizationalUnit != null)
            {
                return $"CN={this.GetSAMAccountName()},{this.ADOrganizationalUnit.ADDistinguishedName}";
            }
            else
            {
                throw new Exception("Organizational unit must be provided to generate distinguished name.");
            }
        }

        public string GetEmailAddress()
        {
            return $"{this.GetSAMAccountName()}@{this.Domain.Name}";
        }
    }
}
