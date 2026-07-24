using Microsoft.AspNetCore.DataProtection;
using NewUserSite.Data;
using NewUserSite.Models;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace NewUserSite.Services
{

    [SupportedOSPlatform("windows")]
    public class NewUserService
    {
        private readonly IDataProtectionProvider _provider;
        public NewUserService(IDataProtectionProvider provider)
        {
            _provider = provider;
        }
        public void CreateNewUser(ADSearcher adSearcher, NewUser newUser)
        {
            var protector = _provider.CreateProtector("ADSearcherPassword");
                var decryptedPassword = protector.Unprotect(adSearcher.Password);
                using (PrincipalContext principalContext = new PrincipalContext(
                    ContextType.Domain,
                    adSearcher.DomainControllerLocation,
                    adSearcher.DomainControllerRoot,
                    adSearcher.Username,
                    decryptedPassword
                    ))
                {
                    Console.WriteLine($"Connected to {adSearcher.DomainControllerLocation}");
                    UserPrincipal templateAccount = UserPrincipal.FindByIdentity(principalContext, newUser.NewUserTemplate.TemplateSAMAccountName) ?? throw new Exception("Template user not found in Active Directory.");

                    UserPrincipal? accountCheck = UserPrincipal.FindByIdentity(principalContext, newUser.GetSAMAccountName());
                    if (accountCheck != null)
                    {
                        throw new Exception($"An account with the SAM account name {newUser.GetSAMAccountName()} already exists in Active Directory.");
                    }
                    else
                    {
                        Console.WriteLine($"Creating new user {newUser.GetSAMAccountName()}");
                        using (UserPrincipal newUserAccount = new UserPrincipal(principalContext))
                        {
                            newUserAccount.Name = newUser.GetDisplayName();
                            newUserAccount.SamAccountName = newUser.GetSAMAccountName();
                            newUserAccount.DisplayName = newUser.GetDisplayName();
                            newUserAccount.GivenName = newUser.FirstName;
                            newUserAccount.Surname = newUser.LastName;
                            newUserAccount.Description = templateAccount.Description;
                            newUserAccount.UserPrincipalName = newUser.GetEmailAddress();
                            newUserAccount.EmailAddress = newUser.GetEmailAddress();
                            newUserAccount.Enabled = true;
                            newUserAccount.Save();

                            try
                            {
                                DirectoryEntry userEntry = newUserAccount.GetUnderlyingObject() as DirectoryEntry;
                                if (userEntry != null)
                                {
                                    DirectoryEntry targetOU = new DirectoryEntry($"LDAP://{adSearcher.DomainControllerLocation}/{newUser.ADOrganizationalUnit.ADDistinguishedName}", adSearcher.Username, decryptedPassword);
                                    userEntry.MoveTo(targetOU);
                                    userEntry.CommitChanges();
                                    targetOU.Close();
                                    Console.WriteLine($"{newUser.GetSAMAccountName()} moved to {newUser.ADOrganizationalUnit.Name}");
                                }
                            }
                            catch (COMException comEx)
                            {
                                Console.WriteLine($"Failed to move user to target OU: {comEx.Message}");
                            }
                            Console.WriteLine($"New user {newUser.GetSAMAccountName()} created successfully.");
                        }
                    }
                    UserPrincipal targetAccount = UserPrincipal.FindByIdentity(principalContext, newUser.GetSAMAccountName());

                    var templateUserGroups = templateAccount.GetGroups()
                        .OfType<GroupPrincipal>()
                        .Select(g => g.SamAccountName)
                        .ToList();

                    foreach (string groupName in templateUserGroups)
                    {
                        try
                        {
                            GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, groupName);
                            if (group != null)
                            {
                                group.Members.Add(targetAccount);
                                group.Save();
                            }
                        }
                        catch (PrincipalExistsException)
                        {
                            Console.WriteLine($"User {newUser.GetSAMAccountName()} is already a member of group {groupName}. Skipping.");
                        }
                        catch (PrincipalOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Failed to add user to group {groupName}");
                        }
                    }
                }
            }
        }
        
    }
