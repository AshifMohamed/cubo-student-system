using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Lecturer> Lecturer { get; set; }

    }
}
