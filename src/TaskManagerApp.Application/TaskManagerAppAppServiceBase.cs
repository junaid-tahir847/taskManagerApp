using Abp.Application.Services;

namespace TaskManagerApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TaskManagerAppAppServiceBase : ApplicationService
    {
        protected TaskManagerAppAppServiceBase()
        {
            LocalizationSourceName = TaskManagerAppConsts.LocalizationSourceName;
        }
    }
}