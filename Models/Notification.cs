using System.ComponentModel.DataAnnotations;

namespace NewUserSite.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public bool IsEnabled { get; set; }
        public enum Action
        {
            UserCreated,
        }
        public string? NotificationText { get; set; }
        public string? NotificationSubject { get; set; }
        public List<AppUser> NotificationRecipients { get; set; } = new List<AppUser>();
    }
}

