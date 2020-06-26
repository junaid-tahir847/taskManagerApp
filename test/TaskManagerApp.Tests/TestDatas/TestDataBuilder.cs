using TaskManagerApp.EntityFrameworkCore;
using TaskManagerApp.Tasks;

namespace TaskManagerApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly TaskManagerAppDbContext _context;

        public TestDataBuilder(TaskManagerAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
            _context.Tasks.AddRange(
            new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality."),
            new Task("Clean your room") { State = TaskState.Completed }
            );
        }
    }
}