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

        public bool CheckStudentExists(string id)
        {
            return _repoWrapper.Student.CheckRecordExists(e => e.StudentId.Equals(id));
        }

        public void CreateStudent(Student student)
        {
            student.joinedYear = DateHelper.GetCurrentyear();
            var count = _repoWrapper.Student.GetCurrentYearStdCount() + 1;
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

        public IEnumerable<Student> GetAllStudents()
        {
            return _repoWrapper.Student.FindAll();
        }

        public Student GetStudent(string id)
        {            
            return _repoWrapper.Student.FindStudent(id);       
        }

        public void SaveStudent()
        {
            try
            {
                _repoWrapper.Student.Save();
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
