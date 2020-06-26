using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Services.TaskAppService;
using TaskManagerApp.Tasks.Dto;
using TaskManagerApp.Web.Models.Tasks;

namespace TaskManagerApp.Web.Controllers
{
    public class TasksController : TaskManagerAppControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items);
            return View(model);
            //var output = await _taskAppService.GetAll(input);
            //var model = new IndexViewModel(output.Items)
            //{
            //    SelectedTaskState = input.State
            //};
            //return View(model);
        }
    }

    /*
     I derived from SimpleTaskAppControllerBase (which is derived from AbpController) that contains common base code for Controllers in this application.
 I injected ITaskAppService in order to get list of tasks.*/
 }
