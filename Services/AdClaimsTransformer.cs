using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using NewUserSite.Services;

namespace NewUserSite.Services
{
    public class AdClaimsTransformer : IClaimsTransformation
    {
        private readonly UserStateService _userStateService;

        public AdClaimsTransformer(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity is not ClaimsIdentity identity || !identity.IsAuthenticated)
                return principal;

            var name = identity.Name;
            if (string.IsNullOrEmpty(name))
                return principal;

            try
            {
                var adUser = await _userStateService.GetUserAndGroupsAsync(name);
                if (adUser is null) return principal;

                foreach (var group in adUser.Groups)
                {
                    if (!identity.HasClaim(ClaimTypes.Role, group.Name))
                        identity.AddClaim(new Claim(ClaimTypes.Role, group.Name));

                    if (!identity.HasClaim(ClaimTypes.Role, group.Sid))
                        identity.AddClaim(new Claim(ClaimTypes.Role, group.Sid));
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
            return principal;
        }
    }
}
