using Abp.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerApp.Tasks;
using TaskManagerApp.Tasks.Dto;

namespace TaskManagerApp.Web.Models.Tasks
{

    //public IReadOnlyList<TaskListDto> Tasks { get; }

    //public class IndexViewModel(IReadOnlyList<TaskListDto> tasks)
    //{
    //    Tasks = tasks;
    //}

    //public string GetTaskLabel(TaskListDto task)
    //{
    //    switch (task.State)
    //    {
    //        case TaskState.Open:
    //            return "label-success";
    //        default:
    //            return "label-default";
    //    }
    //}
    /*
    Instead of directly passing result of the GetAll method to the view, I created an IndexViewModel class in the .Web project which is shown Below:
    This simple view model gets a list of tasks (which is provided from ITaskAppService) in it's constructor. It also has GetTaskLabel method that
    will be used in the view to select a Bootstrap label class for given task.*/


    public class IndexViewModel
    {
        public IReadOnlyList<TaskListDto> Tasks { get; }
        public IndexViewModel(IReadOnlyList<TaskListDto> tasks)
        {
            Tasks = tasks;
        }

        public string GetTaskLabel(TaskListDto task)
        {
            switch (task.State)
            {
                case TaskState.Open:
                    return "label-success";
                default:
                    return "label-default";
            }
        }

        public TaskState? SelectedTaskState { get; set; }

        public List<SelectListItem> GetTasksStateSelectListItems(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = localizationManager.GetString(TaskManagerAppConsts.LocalizationSourceName, "AllTasks"),
                Value = "",
                Selected = SelectedTaskState == null
            }
        };

            list.AddRange(Enum.GetValues(typeof(TaskState))
                    .Cast<TaskState>()
                    .Select(state =>
                        new SelectListItem
                        {
                            Text = localizationManager.GetString(TaskManagerAppConsts.LocalizationSourceName, $"TaskState_{state}"),
                            Value = state.ToString(),
                            Selected = state == SelectedTaskState
                        })
            );

            return list;
        }
    }
   

}
