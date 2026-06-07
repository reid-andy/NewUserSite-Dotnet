namespace NewUserSite.Models
{
    public class AppUser
    {

        private int Id { get; }
        private string? Username { get; set; }
        internal enum PermissionLevel
        {
            User,
            Admin
        }
        internal string? EmailAddress { get; set; }

    }
}
