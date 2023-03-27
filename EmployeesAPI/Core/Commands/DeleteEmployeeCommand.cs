using MediatR;

namespace EmployeesAPI.Core.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
