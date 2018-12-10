using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServerApp.Interfaces;
using ServerApp.Interfaces.Implementationss;
using ServerApp.Models;
using ServerApp.Services;
using ServerApp.Services.Service_Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureMVCVersion(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        public static void ConfigureMVCJson(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DatabaseContext"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureStudentService(this IServiceCollection services)
        {
            services.AddScoped<IStudentDBService, StudentDBService>();
        }

        public static void ConfigureLecturerService(this IServiceCollection services)
        {
            services.AddScoped<ILecturerDBService, LecturerDBService>();
        }

        public static void ConfigureUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserDBService, UserDBService>();
        }

        public static void ConfigureCourseService(this IServiceCollection services)
        {
            services.AddScoped<ICourseDBService, CourseDBService>();
        }
    }
}
