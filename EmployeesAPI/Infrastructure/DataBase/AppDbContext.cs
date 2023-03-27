using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Core.Interfaces;
using System.Numerics;
using EmployeesAPI.Presentation.Models;
using EmployeesAPI.Infrastructure.EntityTypeConfigurations.Fluent;

namespace EmployeesAPI.Infrastructure.DataBase
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeEntityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
