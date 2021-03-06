﻿using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<Course> FindCourse(string id);
    }
}
