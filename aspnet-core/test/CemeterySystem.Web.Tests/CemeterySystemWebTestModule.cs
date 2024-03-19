using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CemeterySystem.EntityFrameworkCore;
using CemeterySystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CemeterySystem.Web.Tests
{
    [DependsOn(
        typeof(CemeterySystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CemeterySystemWebTestModule : AbpModule
    {
        public CemeterySystemWebTestModule(CemeterySystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CemeterySystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CemeterySystemWebMvcModule).Assembly);
        }
    }
}