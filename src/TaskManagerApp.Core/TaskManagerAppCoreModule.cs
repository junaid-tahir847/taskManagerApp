using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagerApp.Localization;

namespace TaskManagerApp
{
    public class TaskManagerAppCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            TaskManagerAppLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagerAppCoreModule).GetAssembly());
        }
    }
}