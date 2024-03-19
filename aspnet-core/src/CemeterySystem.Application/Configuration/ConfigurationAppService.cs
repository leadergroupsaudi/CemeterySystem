using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CemeterySystem.Configuration.Dto;

namespace CemeterySystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CemeterySystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
