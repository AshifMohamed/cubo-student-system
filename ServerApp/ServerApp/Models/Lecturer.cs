using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LecturerId { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public double LecturerSalary { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Course")]
        public string LecturerCourse { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Image")]
        public int LecturerImage { get; set; }
        public Image Image { get; set; }
    }
}
