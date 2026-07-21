using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public enum Role {Admin, User};
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
        public string? ADGroupName { get; set; }

    }
}
