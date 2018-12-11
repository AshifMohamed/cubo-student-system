using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> FindUser(string username);
        Task<bool> UserExists(string username, string password);
    }
}
