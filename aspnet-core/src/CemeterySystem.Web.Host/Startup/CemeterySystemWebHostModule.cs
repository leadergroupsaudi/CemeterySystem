using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CemeterySystem.Configuration;

namespace CemeterySystem.Web.Host.Startup
{
    [DependsOn(
       typeof(CemeterySystemWebCoreModule))]
    public class CemeterySystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CemeterySystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CemeterySystemWebHostModule).GetAssembly());
        }
    }
}
