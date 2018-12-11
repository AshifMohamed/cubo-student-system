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

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUser(string id);

        void UpdateUser(string id, User user);

        Task SaveUser();

        Task<bool> CheckUserExists(User user);

        Task<bool> CheckUsernameExists(string username);
    }
}
