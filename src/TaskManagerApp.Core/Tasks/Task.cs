using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerApp.Persons;

namespace TaskManagerApp.Tasks
{
    [Table("Tasks")]
    public class Task : Entity, IHasCreationTime

    //  Task class is Derived from ABP's base Entity class, which includes Id property as int by default.
    //  Entity<TPrimaryKey>, to choice a different PK type.
    //  IHasCreationTime is a simple interface just defines CreationTime property (it's good to use a standard name for CreationTime).
    //  Task entity defines a required Title and an optional Description.

    {
        [ForeignKey(nameof(AssignedPersonId))]
        public Person AssignedPerson { get; set; }
        public int? AssignedPersonId { get; set; }
        //Guid guid = Guid.NewGuid();

        //AssignedPerson is optional. So, as task can be assigned to a person or can be unassigned.
        public Task(string title, string description = null, int? assignedPersonId = null)
        : this()
        {
            Title = title;
            Description = description;
            AssignedPersonId = assignedPersonId;
        }
        // I'm also adding AssignedPerson property to the Task entity (only sharing the changed parts here):
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }
        // TaskState is a simple enum to define states of a Task.

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        // Clock.Now returns DateTime.Now by default. But it provides an abstraction, 
        //so we can easily switch to DateTime.UtcNow in the feature if it's needed. 
        //Always use Clock.Now instead of DateTime.Now while working with ABP framework.

        //public Task(string title, string description = null)
        //        : this()
        //{
        //    Title = title;
        //    Description = description;
        //}
    }

    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }


}
