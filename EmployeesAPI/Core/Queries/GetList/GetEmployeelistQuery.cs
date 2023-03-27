using MediatR;

namespace EmployeesAPI.Core.Queries.GetList
{
    public class GetEmployeelistQuery : IRequest<EmployeelistVm>
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
