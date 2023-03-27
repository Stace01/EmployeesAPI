using EmployeesAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Infrastructure.DataBase
{
    public static class DependencyInjection
    {
        // Метод расширения для добавления контекста
        // базы данных в веб приложении.
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            return services;
        }
    }
}
