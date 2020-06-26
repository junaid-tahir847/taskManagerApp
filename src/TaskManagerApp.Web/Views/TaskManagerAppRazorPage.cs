using Abp.AspNetCore.Mvc.Views;

namespace TaskManagerApp.Web.Views
{
    public abstract class TaskManagerAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected TaskManagerAppRazorPage()
        {
            LocalizationSourceName = TaskManagerAppConsts.LocalizationSourceName;
        }
    }
}
