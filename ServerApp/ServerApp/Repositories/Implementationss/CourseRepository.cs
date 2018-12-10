using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces.Implementationss
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Course FindCourse(string id)
        {
            return RepositoryContext.Course
                                       .Where(c => c.CourseId.Equals(id))                                     
                                       .First();
        }
    }
}
