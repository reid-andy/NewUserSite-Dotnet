using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public enum PermissionLevel
    {
        User,
        Admin
    }
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public PermissionLevel PermissionLevel { get; set; }
        public string? EmailAddress { get; set; }

    }
}
