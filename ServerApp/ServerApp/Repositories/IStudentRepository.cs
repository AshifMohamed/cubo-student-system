using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<Student> FindStudent(string id);
        Task<bool> StudentExists(string id);
        Task<int> GetCurrentYearStdCount();
    }
}
