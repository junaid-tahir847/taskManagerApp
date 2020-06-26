using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace TaskManagerApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(TaskManagerAppCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class TaskManagerAppEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagerAppEntityFrameworkCoreModule).GetAssembly());
        }
    }
}