using NewUserSite.Models;
using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;

namespace NewUserSite.Services
{

    [SupportedOSPlatform("windows")]
    public class NewUserService
    {

        public void CreateNewUser(ADSearcher adSearcher, NewUser newUser)
        {

            using (PrincipalContext principalContext = new PrincipalContext(
                ContextType.Domain,
                adSearcher.DomainControllerLocation,
                adSearcher.DomainControllerRoot,
                adSearcher.Username,
                adSearcher.Password
                ))
            {
                Console.WriteLine($"Connected to {adSearcher.DomainControllerLocation}");
                UserPrincipal templateAccount = UserPrincipal.FindByIdentity(principalContext, newUser.NewUserTemplate.TemplateSAMAccountName) ?? throw new Exception("Template user not found in Active Directory.");

                UserPrincipal? accountCheck = UserPrincipal.FindByIdentity(principalContext, newUser.getSAMAccountName());
                if (accountCheck != null)
                {
                    throw new Exception($"An account with the SAM account name {newUser.getSAMAccountName()} already exists in Active Directory.");
                }
                else
                {
                    Console.WriteLine($"Creating new user {newUser.getSAMAccountName()}");
                    using (UserPrincipal newUserAccount = new UserPrincipal(principalContext))
                    {
                        newUserAccount.SamAccountName = newUser.getSAMAccountName();
                        newUserAccount.DisplayName = $"{newUser.FirstName} {newUser.LastName}";
                        newUserAccount.GivenName = newUser.FirstName;
                        newUserAccount.Surname = newUser.LastName;
                        newUserAccount.Description = templateAccount.Description;
                        newUserAccount.Save();
                        Console.WriteLine($"New user {newUser.getSAMAccountName()} created successfully.");
                    }
                }
                UserPrincipal targetAccount = UserPrincipal.FindByIdentity(principalContext, newUser.getSAMAccountName());

                PrincipalSearchResult<Principal> templateUserGroups = templateAccount.GetGroups();

                foreach (Principal principal in templateUserGroups)
                {
                    if (principal is GroupPrincipal group)
                    {
                        group.Members.Add(targetAccount);
                        group.Save();
                    }
                }

            }
        }




    }
}