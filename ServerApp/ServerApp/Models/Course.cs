using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; }
    }
}
