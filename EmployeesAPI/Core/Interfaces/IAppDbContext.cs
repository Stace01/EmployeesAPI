using EmployeesAPI.Presentation.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeesAPI.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
