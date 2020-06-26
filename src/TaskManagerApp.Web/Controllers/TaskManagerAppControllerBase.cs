using Abp.AspNetCore.Mvc.Controllers;

namespace TaskManagerApp.Web.Controllers
{
    public abstract class TaskManagerAppControllerBase: AbpController
    {
        protected TaskManagerAppControllerBase()
        {
            LocalizationSourceName = TaskManagerAppConsts.LocalizationSourceName;
        }
    }
}