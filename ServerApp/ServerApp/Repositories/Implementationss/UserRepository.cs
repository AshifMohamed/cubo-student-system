using Microsoft.EntityFrameworkCore;
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

        public async Task<User> FindUser(string username)
        {
            return await RepositoryContext.User
                            .Where(u => u.UserName.Equals(username))                     
                            .FirstAsync();
        }

        public async Task<bool> UserExists(string username, string password)
        {
            return await RepositoryContext.User.AnyAsync(u => u.UserName.Equals(username) &&
            u.Password.Equals(password));
        }
    }
}
