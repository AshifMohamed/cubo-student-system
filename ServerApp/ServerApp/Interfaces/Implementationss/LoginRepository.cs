using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class LoginRepository : RepositoryBase<User>, ILoginRepository
    {
        public LoginRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
