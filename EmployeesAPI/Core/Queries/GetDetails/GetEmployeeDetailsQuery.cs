using MediatR;

namespace EmployeesAPI.Core.Queries.GetDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
