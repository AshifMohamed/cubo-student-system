using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Services
{
    public interface ILecturerDBService
    {
        void DeleteLecturer(Lecturer lecturer);

        void CreateLecturer(Lecturer lecturer);

        Task<IEnumerable<Lecturer>> GetAllLecturers();

        Task<Lecturer> GetLecturer(string lecUsername);

        void UpdateLecturer(int id, Lecturer lecturer);

        Task SaveLecturer();

        Task<bool> CheckLecturerExists(int id);
    }
}
