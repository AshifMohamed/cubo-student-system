using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Constants;
using ServerApp.Interfaces;
using ServerApp.Models;

namespace ServerApp.Services.Service_Implementations
{
    public class LecturerDBService : ILecturerDBService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public LecturerDBService(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        public async Task<bool> CheckLecturerExists(int id)
        {
            return await _repoWrapper.Lecturer.FindAsync(e => e.LecturerId.Equals(id));
        }

        public void CreateLecturer(Lecturer lecturer)
        {
         //   lecturer.LecturerId = ;
            var user = new User
            {
                UserName = lecturer.UserName,
                Password = lecturer.UserName,
                Role = Constant.lecturerRole
            };
            lecturer.Course = null;
            lecturer.User = user;

            _repoWrapper.Lecturer.Create(lecturer);
        }

        public void DeleteLecturer(Lecturer lecturer)
        {
            _repoWrapper.Lecturer.Delete(lecturer);
        }

        public async Task<IEnumerable<Lecturer>> GetAllLecturers()
        {
            return await _repoWrapper.Lecturer.FindAllAsync();
        }

        public async Task<Lecturer> GetLecturer(string lecUsername)
        {
            return await _repoWrapper.Lecturer.FindLecturer(lecUsername);
        }

        public async Task SaveLecturer()
        {
            try
            {
               await _repoWrapper.Lecturer.SaveAsync();
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

        public void UpdateLecturer(int id, Lecturer lecturer)
        {
            _repoWrapper.Lecturer.Update(lecturer);
        }
    }
}
