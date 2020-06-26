using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerApp.Tasks.Dto
{
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }

    [AutoMapFrom(typeof(Task))]
    public class TaskListDto : EntityDto, IHasCreationTime
    {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime CreationTime { get; set; }
            public TaskState State { get; set; }

        /*
        GetAllTasksInput DTO defines input parameters of the GetAll app service method.
        Instead of directly defining the state as method parameter, I added it into a DTO object.
        Thus, I can add other parameters into this DTO later without breaking my existing clients
        (we could directly add a state parameter to the method).
        TaskListDto is used to return a Task data. It's derived from EntityDto,
        which just defines an Id property (we could add Id to our Dto and not derive from EntityDto).
        We defined [AutoMapFrom] attribute to create AutoMapper mapping from Task entity to TaskListDto.
        This attribute is defined in Abp.AutoMapper nuget package.
        Lastly, ListResultDto is a simple class contains a list of items 
        (we could directly return a List<TaskListDto>).*/
    }
}

