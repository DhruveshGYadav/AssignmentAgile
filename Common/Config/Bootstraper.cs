using Common.Models;
using Common.Repositories;
using Common.Repositories.Interfaces;
using Common.Services;
using Common.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Config
{
    public static class Bootstraper
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<AssignmentAIContext>(option => option.UseSqlServer(ConnectionString));
        }
        public static void RegiserRepoService(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeSerice, EmployeeService>();
        }

    }
}
