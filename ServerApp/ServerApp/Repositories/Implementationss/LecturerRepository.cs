using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class LecturerRepository : RepositoryBase<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Lecturer FindLecturer(string lecUsername)
        {
            return RepositoryContext.Lecturer
                           .Where(l => l.UserName.Equals(lecUsername))
                           .Include(l => l.Image)
                           .Include(l => l.Course)
                           .First();
        }
    }
}
