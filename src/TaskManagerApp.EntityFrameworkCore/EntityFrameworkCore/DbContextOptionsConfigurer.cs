using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<TaskManagerAppDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for TaskManagerAppDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
