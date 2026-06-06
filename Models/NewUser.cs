namespace NewUserSite.Models
{
    public class NewUser
    {
        private int Id { get; }
        private string? FirstName { get; set; }
        private string? LastName { get; set; }
        private ADOrganizationalUnit? adOrganizationalUnit { get; set; }
        private NewUserTemplate? newUserTemplate { get; set; }
        private string? SupervisorEmail { get; set; }
        private AppUser CreatedBy { get; set; }
    }
}
