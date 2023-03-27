using MediatR;

namespace EmployeesAPI.Core.Commands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
