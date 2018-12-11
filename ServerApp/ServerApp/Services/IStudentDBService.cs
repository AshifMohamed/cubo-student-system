using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Services
{
    public interface IStudentDBService
    {
        void DeleteStudent(Student student);

        Task CreateStudent(Student student);

        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudent(string id);
        
        void UpdateStudent(string id, Student student);
       
        Task SaveStudent();

        Task<bool> CheckStudentExists(string id);
    }
}
