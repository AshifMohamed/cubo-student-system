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

        Task<IEnumerable<Course>> GetAllCourses();

        Task<Course> GetCourse(string id);

        void UpdateCourse(string id, Course course);

        Task SaveCourse();

        Task<bool> CheckCourseExists(string id);

        Task<bool> CheckCourseNameExists(string courseName);
    }
}
