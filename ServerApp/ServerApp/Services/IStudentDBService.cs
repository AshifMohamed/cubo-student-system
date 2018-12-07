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

        void CreateStudent(Student student);

        IEnumerable<Student> GetAllStudent();

        Student GetStudent(string id);
        
        void UpdateStudent(string id, Student student);
       
        void SaveStudent();

        bool CheckStudentExists(string id);
    }
}
