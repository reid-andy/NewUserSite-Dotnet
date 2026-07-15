using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Principal;

namespace NewUserSite.Services;

public record AdGroupInfo(string Name, string Sid);
public record AdUserInfo(string DisplayName, string SamAccountName, string UserPrincipalName, List<AdGroupInfo> Groups);
[SupportedOSPlatform("windows")]
public class UserStateService
{
    private readonly ILogger<UserStateService> _logger;

    public UserStateService(ILogger<UserStateService> logger)
    {
        _logger = logger;
    }
    public ClaimsPrincipal? CurrentPrincipal { get; private set; }
    public AdUserInfo? CurrentUser { get; private set; }
    public bool IsInitialized { get; private set; }
    public event Action? OnChange;
    public void SetCurrentUser(AdUserInfo? user, ClaimsPrincipal? principal = null)
    {
        CurrentUser = user;
        CurrentPrincipal = principal;
        IsInitialized = true;
        OnChange?.Invoke();
        _logger?.LogInformation("UserStateService.SetCurrentUser called. Has user: {HasUser}", user != null);
    }

    public void SetInitialized()
    {
        IsInitialized = true;
        OnChange?.Invoke();
    }


    // Note: System.DirectoryServices.AccountManagement APIs are synchronous; wrap in Task.Run for async callers.
    public Task<AdUserInfo?> GetUserAndGroupsAsync(string domainUsername)
    {
        return Task.Run(() =>
        {
            if (string.IsNullOrWhiteSpace(domainUsername))
                return null;

            var parts = domainUsername.Split('\\', 2);
            string? domain = parts.Length == 2 ? parts[0] : null;
            string identifier = parts.Length == 2 ? parts[1] : domainUsername;

            // Use domain if supplied; otherwise let PrincipalContext pick the default domain
            using var ctx = domain is not null
                ? new PrincipalContext(ContextType.Domain, domain)
                : new PrincipalContext(ContextType.Domain);

            // Try SAM account name first
            var user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, identifier)
                       ?? UserPrincipal.FindByIdentity(ctx, IdentityType.UserPrincipalName, identifier)
                       ?? UserPrincipal.FindByIdentity(ctx, IdentityType.Name, identifier);

            if (user == null)
                return null;

            var groups = new List<AdGroupInfo>();
            try
            {
                foreach (var g in user.GetAuthorizationGroups() ?? Enumerable.Empty<Principal>())
                {
                    try
                    {
                        var sid = g.Sid?.Value ?? string.Empty;
                        var name = g.SamAccountName ?? g.Name ?? sid;
                        groups.Add(new AdGroupInfo(name, sid));
                    }
                    catch
                    {
                        // ignore problematic group entries
                    }
                }
            }
            catch
            {
                // GetAuthorizationGroups can throw for some accounts; consider fallback logic if needed.
            }

            return new AdUserInfo(user.DisplayName ?? string.Empty, user.SamAccountName ?? string.Empty, user.UserPrincipalName ?? string.Empty, groups);
        });
    }
}
