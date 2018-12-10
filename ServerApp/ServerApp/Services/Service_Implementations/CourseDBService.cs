using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Interfaces;
using ServerApp.Models;

namespace ServerApp.Services.Service_Implementations
{
    public class CourseDBService : ICourseDBService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CourseDBService(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        public bool CheckCourseExists(string id)
        {
            return _repoWrapper.Course.CheckRecordExists(c => c.CourseId.Equals(id));
        }

        public bool CheckCourseNameExists(string courseName)
        {
            return _repoWrapper.Course.CheckRecordExists(c => c.CourseName.Equals(courseName));
        }

        public void CreateCourse(Course course)
        {
            _repoWrapper.Course.Create(course);
        }

        public void DeleteCourse(Course course)
        {
            _repoWrapper.Course.Delete(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _repoWrapper.Course.FindAll();
        }

        public Course GetCourse(string id)
        {
            return _repoWrapper.Course.FindCourse(id);
        }

        public void SaveCourse()
        {
            try
            {
                _repoWrapper.Lecturer.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {

            }
            catch (DbUpdateException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateCourse(string id, Course course)
        {
            _repoWrapper.Course.Update(course);
        }
    }
}
