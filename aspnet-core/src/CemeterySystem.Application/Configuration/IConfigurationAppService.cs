using System.Threading.Tasks;
using CemeterySystem.Configuration.Dto;

namespace CemeterySystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
