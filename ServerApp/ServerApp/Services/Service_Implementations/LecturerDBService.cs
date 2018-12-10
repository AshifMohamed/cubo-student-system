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

        public bool CheckLecturerExists(int id)
        {
            return _repoWrapper.Lecturer.CheckRecordExists(e => e.LecturerId.Equals(id));
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

        public IEnumerable<Lecturer> GetAllLecturers()
        {
            return _repoWrapper.Lecturer.FindAll();
        }

        public Lecturer GetLecturer(string lecUsername)
        {
            return _repoWrapper.Lecturer.FindLecturer(lecUsername);
        }

        public void SaveLecturer()
        {
            try
            {
                _repoWrapper.Lecturer.Save();
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
