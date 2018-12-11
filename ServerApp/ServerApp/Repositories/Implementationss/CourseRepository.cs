using Microsoft.EntityFrameworkCore;
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

        public async Task<Course> FindCourse(string id)
        {
            return await RepositoryContext.Course
                                       .Where(c => c.CourseId.Equals(id))                             
                                       .FirstAsync();
        }
    }
}
