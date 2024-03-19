using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CemeterySystem.Controllers
{
    public abstract class CemeterySystemControllerBase: AbpController
    {
        protected CemeterySystemControllerBase()
        {
            LocalizationSourceName = CemeterySystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
