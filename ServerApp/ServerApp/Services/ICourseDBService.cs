using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Services
{
    public interface ICourseDBService
    {
        void DeleteCourse(Course course);

        void CreateCourse(Course course);

        IEnumerable<Course> GetAllCourses();

        Course GetCourse(string id);

        void UpdateCourse(string id, Course course);

        void SaveCourse();

        bool CheckCourseExists(string id);

        bool CheckCourseNameExists(string courseName);
    }
}
