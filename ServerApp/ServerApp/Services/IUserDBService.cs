using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Services
{
    public interface IUserDBService
    {
        void DeleteUser(User user);

        void CreateUser(User user);

        IEnumerable<User> GetAllUsers();

        User GetUser(string id);

        void UpdateUser(string id, User user);

        void SaveUser();

        bool CheckUserExists(User user);

        bool CheckUsernameExists(string username);
    }
}
