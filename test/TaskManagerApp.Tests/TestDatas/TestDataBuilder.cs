using TaskManagerApp.EntityFrameworkCore;

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
        }
    }
}