using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICourseRepository _course;
        private ILecturerRepository _lecturer;
        private ILoginRepository _login;
        private IStudentRepository _student;
        private IUserRepository _user;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ICourseRepository Course
        {
            get
            {
                if (_course == null)
                {
                    _course = new CourseRepository(_repoContext);
                }

                return _course;
            }
        }

        public ILecturerRepository Lecturer
        {
            get
            {
                if (_lecturer == null)
                {
                    _lecturer = new LecturerRepository(_repoContext);
                }

                return _lecturer;
            }
        }

        public ILoginRepository Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginRepository(_repoContext);
                }

                return _login;
            }
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_repoContext);
                }

                return _student;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

    }
}
