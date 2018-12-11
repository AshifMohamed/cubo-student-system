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

        public async Task<bool> CheckCourseExists(string id)
        {
            return await _repoWrapper.Course.FindAsync(c => c.CourseId.Equals(id));
        }

        public async Task<bool> CheckCourseNameExists(string courseName)
        {
            return await _repoWrapper.Course.FindAsync(c => c.CourseName.Equals(courseName));
        }

        public void CreateCourse(Course course)
        {
            _repoWrapper.Course.Create(course);
        }

        public void DeleteCourse(Course course)
        {
            _repoWrapper.Course.Delete(course);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repoWrapper.Course.FindAllAsync();
        }

        public async Task<Course> GetCourse(string id)
        {
            return await _repoWrapper.Course.FindCourse(id);
        }

        public async Task SaveCourse()
        {
            try
            {
               await _repoWrapper.Lecturer.SaveAsync();
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
