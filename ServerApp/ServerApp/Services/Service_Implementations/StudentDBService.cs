using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Constants;
using ServerApp.Helpers;
using ServerApp.Interfaces;
using ServerApp.Models;

namespace ServerApp.Services.Service_Implementations
{
    public class StudentDBService : IStudentDBService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public StudentDBService(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        public async Task<bool> CheckStudentExists(string id)
        {
            return await _repoWrapper.Student.FindAsync(e => e.StudentId.Equals(id));
        }

        public async Task CreateStudent(Student student)
        {
            student.joinedYear = DateHelper.GetCurrentyear();
            var count = await _repoWrapper.Student.GetCurrentYearStdCount() + 1;
            student.StudentId = student.StudentCourse + student.joinedYear + count;

            var user = new User
            {
                UserName = student.StudentId,
                Password = student.StudentId,
                Role = Constant.studentRole
            };
            student.Course = null;
            student.User = user;

            _repoWrapper.Student.Create(student);
        }

        public void DeleteStudent(Student student)
        {
            _repoWrapper.Student.Delete(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _repoWrapper.Student.FindAllAsync();
        }

        public async Task<Student> GetStudent(string id)
        {            
            return await _repoWrapper.Student.FindStudent(id);       
        }

        public async Task SaveStudent()
        {
            try
            {
                await _repoWrapper.Student.SaveAsync();
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

        public void UpdateStudent(string id, Student student)
        {
            _repoWrapper.Student.Update(student);
        }
    }
}
