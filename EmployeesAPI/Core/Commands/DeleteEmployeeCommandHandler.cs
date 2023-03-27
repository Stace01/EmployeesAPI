using EmployeesAPI.Core.Exceptions;
using EmployeesAPI.Core.Interfaces;
using EmployeesAPI.Presentation.Models;
using MediatR;
using System.Numerics;

namespace EmployeesAPI.Core.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteEmployeeCommandHandler(IAppDbContext appDbContext) =>
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Employees
                .FindAsync(new object[] { request.EmployeeId }, cancellationToken);

            if (entity == null || entity.FullName != request.FullName)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            _appDbContext.Employees.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteEmployeeCommand>.Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
