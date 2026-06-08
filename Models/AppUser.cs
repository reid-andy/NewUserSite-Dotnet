using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public enum PermissionLevel
        {
            User,
            Admin
        }
        public string? EmailAddress { get; set; }

    }
}
