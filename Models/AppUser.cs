namespace NewUserSite.Models
{
    public enum PermissionLevel { User, Admin} 
    public class AppUser
    {

        private int Id { get; }
        private string? Username { get; set; }
        private PermissionLevel PermissionLevel { get; set; }
       
    }
}
