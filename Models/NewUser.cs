namespace NewUserSite.Models
{
    public class NewUser
    {
        private int Id { get; }
        internal string? FirstName { get; set; }
        internal string? LastName { get; set; }
        internal ADOrganizationalUnit? AdOrganizationalUnit { get; set; }
        internal NewUserTemplate? NewUserTemplate { get; set; }
        internal string? SupervisorEmail { get; set; }
        internal AppUser? CreatedBy { get; set; }

        internal string getSAMAccountName()
        {
            if (this.FirstName != null && this.LastName != null)
            {
                return $"{this.FirstName.Substring(0, 1)}{this.LastName}".ToLower();
            }
            else
            {
                throw new Exception("First name and last name must be provided to generate SAM account name.");
            }
        }
    }
}
