using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagerApp.Configuration;
using TaskManagerApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace TaskManagerApp.Web.Startup
{
    [DependsOn(
        typeof(TaskManagerAppApplicationModule), 
        typeof(TaskManagerAppEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class TaskManagerAppWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TaskManagerAppWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(TaskManagerAppConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<TaskManagerAppNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(TaskManagerAppApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagerAppWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TaskManagerAppWebModule).Assembly);
        }
    }
}