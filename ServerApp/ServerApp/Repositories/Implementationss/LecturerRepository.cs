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

        public async Task<Lecturer> FindLecturer(string lecUsername)
        {
            return await RepositoryContext.Lecturer
                           .Where(l => l.UserName.Equals(lecUsername))
                           .Include(l => l.Image)
                           .Include(l => l.Course)
                           .FirstAsync();
        }
    }
}
