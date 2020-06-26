using System.Threading.Tasks;
using TaskManagerApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace TaskManagerApp.Web.Tests.Controllers
{
    public class HomeController_Tests: TaskManagerAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
