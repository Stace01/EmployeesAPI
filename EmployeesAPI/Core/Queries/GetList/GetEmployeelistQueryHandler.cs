using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesAPI.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Core.Queries.GetList
{
    public class GetEmployeelistQueryHandler : IRequestHandler<GetEmployeelistQuery, EmployeelistVm>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetEmployeelistQueryHandler(IAppDbContext appDbContext, IMapper mapper) =>
            (_appDbContext, _mapper) = (appDbContext, mapper);

        public async Task<EmployeelistVm> Handle(GetEmployeelistQuery request, CancellationToken cancellationToken)
        {
            var employeeQuery = await _appDbContext.Employees
                .Where(employee => employee.EmployeeId == request.EmployeeId)
                .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeelistVm { Employees = employeeQuery };
        }
    }
}
