using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace TaskManagerApp
{
    [DependsOn(
        typeof(TaskManagerAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TaskManagerAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagerAppApplicationModule).GetAssembly());
        }
    }
}