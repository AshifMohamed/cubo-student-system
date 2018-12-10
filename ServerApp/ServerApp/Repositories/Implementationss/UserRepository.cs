using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }       

        public User FindUser(string username)
        {
            return RepositoryContext.User
                            .Where(u => u.UserName.Equals(username))                     
                            .First();
        }

        public bool UserExists(string username, string password)
        {
            return RepositoryContext.User.Any(u => u.UserName.Equals(username) &&
            u.Password.Equals(password));
        }
    }
}
