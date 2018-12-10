using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICourseRepository Course { get; }
        ILecturerRepository Lecturer { get; }
        IStudentRepository Student { get; }
        IUserRepository User { get; }

    }
}
