using Interfaces;   
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicactionServices(this IServiceCollection services, IConfiguration config)
        {
             services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}