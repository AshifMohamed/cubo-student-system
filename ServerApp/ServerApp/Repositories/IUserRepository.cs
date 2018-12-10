using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User FindUser(string username);
        bool UserExists(string username, string password);
    }
}
