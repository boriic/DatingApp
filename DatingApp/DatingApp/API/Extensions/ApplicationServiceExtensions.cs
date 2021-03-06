using DatingApp.API.Helpers;
using DatingApp.API.Interfaces;
using DatingApp.API.Repository;
using DatingApp.API.Repository.Common;
using DatingApp.API.Services;
using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                //for some reason get connection string method is not working, returns empty connection string from appsettings.json
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
