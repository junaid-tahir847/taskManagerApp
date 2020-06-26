using System;
using System.Threading.Tasks;
using Abp.TestBase;
using TaskManagerApp.EntityFrameworkCore;
using TaskManagerApp.Tests.TestDatas;

namespace TaskManagerApp.Tests
{
    public class TaskManagerAppTestBase : AbpIntegratedTestBase<TaskManagerAppTestModule>
    {
        public TaskManagerAppTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<TaskManagerAppDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<TaskManagerAppDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<TaskManagerAppDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TaskManagerAppDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<TaskManagerAppDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<TaskManagerAppDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<TaskManagerAppDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TaskManagerAppDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
