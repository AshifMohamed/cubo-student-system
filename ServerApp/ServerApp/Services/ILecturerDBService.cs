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

        IEnumerable<Lecturer> GetAllLecturers();

        Lecturer GetLecturer(string lecUsername);

        void UpdateLecturer(int id, Lecturer lecturer);

        void SaveLecturer();

        bool CheckLecturerExists(int id);
    }
}
