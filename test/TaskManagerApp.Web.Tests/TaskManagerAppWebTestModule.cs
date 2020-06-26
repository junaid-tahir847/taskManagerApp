using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagerApp.Web.Startup;
namespace TaskManagerApp.Web.Tests
{
    [DependsOn(
        typeof(TaskManagerAppWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class TaskManagerAppWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagerAppWebTestModule).GetAssembly());
        }
    }
}