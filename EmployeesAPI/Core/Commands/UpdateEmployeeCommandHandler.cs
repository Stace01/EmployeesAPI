using EmployeesAPI.Core.Exceptions;
using EmployeesAPI.Core.Interfaces;
using MediatR;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Presentation.Models;

namespace EmployeesAPI.Core.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeCommandHandler(IAppDbContext appDbContext) =>
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

        // Unit - это тип, означающий пустой ответ.
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == request.EmployeeId, cancellationToken);

            if (entity == null || entity.FullName != request.FullName)
            {
                throw new NotFoundException(nameof(Employee), request.FullName);
            }

            //entity.FullName = request.FullName;
            entity.Position = request.Position;
            entity.UpdatedDateTime = DateTime.UtcNow;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateEmployeeCommand>.Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
