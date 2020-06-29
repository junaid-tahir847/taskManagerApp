using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Persons
{
    [Table("Persons")]
    public class Person: Entity, IHasCreationTime //: AuditedEntity<Guid>
    {
        // Person concept to the application to assign tasks to people. So, I define a simple Person
        /* This time, I set Id (primary key)  type as Guid, for demonstration. I also derived from AuditedEntity 
         (which has CreationTime, CreaterUserId, LastModificationTime and LastModifierUserId properties) instead 
         of base Entity class.
       */
        public int Id { get; set; }
        public const int MaxNameLength = 32;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

        public Person()
        {
            CreationTime = Clock.Now;  // To do
        }
        public Person(string name)
        {
            Name = name;
        }
     
    }
}
