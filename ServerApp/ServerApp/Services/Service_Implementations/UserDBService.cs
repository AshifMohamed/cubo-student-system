using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Interfaces;
using ServerApp.Models;

namespace ServerApp.Services.Service_Implementations
{
    public class UserDBService : IUserDBService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserDBService(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        public bool CheckUserExists(User user)
        {
            return _repoWrapper.User.UserExists(user.UserName, user.Password);
        }

        public bool CheckUsernameExists(string username)
        {
            return _repoWrapper.User.CheckRecordExists(u => u.UserName.Equals(username));
        }

        public void CreateUser(User user)
        {
            _repoWrapper.User.Create(user);
        }

        public void DeleteUser(User user)
        {
            _repoWrapper.User.Delete(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repoWrapper.User.FindAll();
        }

        public User GetUser(string username)
        {
            return _repoWrapper.User.FindUser(username);
        }

        public void SaveUser()
        {
            try
            {
                _repoWrapper.User.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {

            }
            catch (DbUpdateException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateUser(string id, User user)
        {
            _repoWrapper.User.Update(user);
        }
    }
}
