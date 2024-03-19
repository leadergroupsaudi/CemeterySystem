using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CemeterySystem.Authorization;

namespace CemeterySystem
{
    [DependsOn(
        typeof(CemeterySystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CemeterySystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CemeterySystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CemeterySystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
