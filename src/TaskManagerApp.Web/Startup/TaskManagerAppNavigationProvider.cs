using Abp.Application.Navigation;
using Abp.Localization;

namespace TaskManagerApp.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class TaskManagerAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                          "TaskList",
                    L("TaskList"),
                    url: "Tasks",
                    icon: "fa fa-tasks"
                    )
                );
            // To add new menu item in nav bar
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaskManagerAppConsts.LocalizationSourceName);
        }
    }
}
