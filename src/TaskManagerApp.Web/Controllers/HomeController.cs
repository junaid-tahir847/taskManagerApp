using Microsoft.AspNetCore.Mvc;

namespace TaskManagerApp.Web.Controllers
{
    public class HomeController : TaskManagerAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}