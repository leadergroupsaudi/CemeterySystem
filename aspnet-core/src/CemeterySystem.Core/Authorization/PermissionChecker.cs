using Abp.Authorization;
using CemeterySystem.Authorization.Roles;
using CemeterySystem.Authorization.Users;

namespace CemeterySystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
