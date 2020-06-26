using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Tasks;

namespace TaskManagerApp.EntityFrameworkCore
{
    public class TaskManagerAppDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Task> Tasks { get; set; }
        public TaskManagerAppDbContext(DbContextOptions<TaskManagerAppDbContext> options) 
            : base(options)
        {

        }
    }
}
