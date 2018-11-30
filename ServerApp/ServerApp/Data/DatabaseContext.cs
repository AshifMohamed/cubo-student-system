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

        public DbSet<ServerApp.Models.User> User { get; set; }

        public DbSet<ServerApp.Models.Course> Course { get; set; }

        public DbSet<ServerApp.Models.Student> Student { get; set; }

        public DbSet<ServerApp.Models.Lecturer> Lecturer { get; set; }
    }
}
