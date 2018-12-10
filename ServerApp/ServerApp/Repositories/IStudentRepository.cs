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
        Student FindStudent(string id);
        bool StudentExists(string id);
        int GetCurrentYearStdCount();
    }
}
