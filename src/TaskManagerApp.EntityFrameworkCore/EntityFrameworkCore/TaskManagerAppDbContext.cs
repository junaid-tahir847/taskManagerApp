using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.EntityFrameworkCore
{
    public class TaskManagerAppDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public TaskManagerAppDbContext(DbContextOptions<TaskManagerAppDbContext> options) 
            : base(options)
        {

        }
    }
}
