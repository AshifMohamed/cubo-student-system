using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Student
    {
        [ForeignKey("User")]
        public string StudentId { get; set; }
        public virtual User User { get; set; }

        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        [ForeignKey("Course")]
        public string StudentCourse { get; set; }
        public Course Course { get; set; }
    }
}
