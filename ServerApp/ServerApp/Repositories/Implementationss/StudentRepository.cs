using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {

        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Student FindStudent(string id)
        {
             return RepositoryContext.Student
                .Where(s => s.StudentId.Equals(id))
                .Include(s => s.Image)
                .Include(s => s.Course)
                .First();
        }

        public int GetCurrentYearStdCount()
        {
            string currentYear = DateTime.Now.Year.ToString();
             return RepositoryContext.Student
                     .Where(s => s.joinedYear.Equals(currentYear))
                     .Count();
        }

        public bool StudentExists(string id)
        {
             return RepositoryContext.Student.Any(e => e.StudentId == id);
        }
    }
}
