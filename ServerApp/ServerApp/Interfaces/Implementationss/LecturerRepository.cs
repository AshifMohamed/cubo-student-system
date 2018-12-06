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
    }
}
