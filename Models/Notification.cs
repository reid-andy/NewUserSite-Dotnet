namespace NewUserSite.Models
{
    public class Notification
    {
        private int Id { get; }
        internal bool IsEnabled { get; set; }
        internal enum Action
        {
            UserCreated,
        }
        internal string? NotificationText { get; set; }
        internal string? NotificationSubject { get; set; }
        internal List<AppUser> NotificationRecipients { get; set; } = new List<AppUser>();
    }
}

