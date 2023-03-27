using AutoMapper;
using EmployeesAPI.Core.Exceptions;
using EmployeesAPI.Core.Interfaces;
using MediatR;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Presentation.Models;

namespace EmployeesAPI.Core.Queries.GetDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(IAppDbContext appDbContext, IMapper mapper) =>
            (_appDbContext, _mapper) = (appDbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Employees
                .FirstOrDefaultAsync(employee => employee.FullName == request.FullName, cancellationToken);

            if (entity == null || entity.EmployeeId != request.EmployeeId)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
