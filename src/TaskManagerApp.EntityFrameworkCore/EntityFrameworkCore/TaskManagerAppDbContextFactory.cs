using TaskManagerApp.Configuration;
using TaskManagerApp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskManagerApp.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class TaskManagerAppDbContextFactory : IDesignTimeDbContextFactory<TaskManagerAppDbContext>
    {
        public TaskManagerAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TaskManagerAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(TaskManagerAppConsts.ConnectionStringName)
            );

            return new TaskManagerAppDbContext(builder.Options);
        }
    }
}