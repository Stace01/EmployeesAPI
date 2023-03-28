using EmployeesAPI.Presentation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;
using System.Xml.Linq;

namespace EmployeesAPI.Infrastructure.EntityTypeConfigurations.Fluent
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.EmployeeId).IsUnique();
            builder.Property(e => e.EmployeeId).HasColumnName("Id");
            builder.Property(e => e.FullName).IsRequired().IsConcurrencyToken().HasMaxLength(40).HasColumnName("ФИО сотрудника");
            builder.Property(e => e.Position).IsRequired().HasMaxLength(40).HasColumnName("Должность");
            builder.Property(e => e.CreatedDateTime).IsRequired().HasMaxLength(40).HasColumnName("Дата создания");
            builder.Property(e => e.UpdatedDateTime).IsRequired().HasMaxLength(40).HasColumnName("Дата изменения");
        }
    }
}
