using EmployeesAPI.Core.Interfaces;
using EmployeesAPI.Presentation.Models;
using MediatR;
using System.Numerics;

namespace EmployeesAPI.Core.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateEmployeeCommandHandler(IAppDbContext appDbContext) =>
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                FullName = request.FullName,
                Position = request.Position,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = null
            };

            await _appDbContext.Employees.AddAsync(employee, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return employee.EmployeeId;
        }
    }
}
