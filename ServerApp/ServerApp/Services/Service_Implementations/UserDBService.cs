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

        public async Task<bool> CheckUserExists(User user)
        {
            return await _repoWrapper.User.UserExists(user.UserName, user.Password);
        }

        public async Task<bool> CheckUsernameExists(string username)
        {
            return await _repoWrapper.User.FindAsync(u => u.UserName.Equals(username));
        }

        public void CreateUser(User user)
        {
            _repoWrapper.User.Create(user);
        }

        public void DeleteUser(User user)
        {
            _repoWrapper.User.Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repoWrapper.User.FindAllAsync();
        }

        public async Task<User> GetUser(string username)
        {
            return await _repoWrapper.User.FindUser(username);
        }

        public async Task SaveUser()
        {
            try
            {
                await _repoWrapper.User.SaveAsync();
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
