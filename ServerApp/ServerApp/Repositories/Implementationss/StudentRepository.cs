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

        public async Task<Student> FindStudent(string id)
        {
             return await RepositoryContext.Student
                .Where(s => s.StudentId.Equals(id))
                .Include(s => s.Image)
                .Include(s => s.Course)
                .FirstAsync();
        }

        public async Task<int> GetCurrentYearStdCount()
        {
            string currentYear = DateTime.Now.Year.ToString();
             return await RepositoryContext.Student
                     .Where(s => s.joinedYear.Equals(currentYear))
                     .CountAsync();
        }

        public async Task<bool> StudentExists(string id)
        {
             return await RepositoryContext.Student.AnyAsync(e => e.StudentId == id);
        }
    }
}
