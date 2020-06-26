using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerApp.Tasks.Dto;
using Task = TaskManagerApp.Tasks.Task;
using System.Linq;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;


namespace TaskManagerApp.Services.TaskAppService
{


    public class TaskAppService : TaskManagerAppAppServiceBase, ITaskAppService
    {
        /* TaskAppService is derived from TaskManagerAppAppServiceBase included in the startup template (which is derived from ABP's ApplicationService class).
         * This is not required, app services can be plain classes. But ApplicationService base class has some pre-injected services (like ObjectMapper used here).
        I used dependency injection to get a repository.
        https://aspnetboilerplate.com/Pages/Documents/Dependency-Injection
        Repositories are used to abstract database operations for entities. ABP creates a pre-defined repository (like IRepository<Task> here) 
        for each entity to perform common tasks. IRepository.GetAll() used here returns an IQueryable to query entities.
        WhereIf is an extension method of ABP to simplify conditional usage of IQueryable.Where method.
        ObjectMapper (which somes from the ApplicationService base class and implemented via AutoMapper by default) is used to map list of Task 
        objects to list of TaskListDtos objects.
        */


        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }

    }

}