using Interfaces;   
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Helpers;


namespace Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicactionServices(this IServiceCollection services, IConfiguration config)
        {
             services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<IPhotoService, PhotoService>();
             services.AddScoped<LogUserActivity>();
             services.AddScoped<IUserRepository, UserRepository>();
             services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
             services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}