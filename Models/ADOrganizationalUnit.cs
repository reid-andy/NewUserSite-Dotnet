namespace NewUserSite.Models
{
    public class ADOrganizationalUnit
    {
        private int Id { get; }
        private string? Name { get; set; }
        internal string? ADDistinguishedName { get; set; }
        private List<NewUserTemplate>? NewUserTemplates { get; set; }
    }
}
