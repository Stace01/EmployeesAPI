using MediatR;

namespace EmployeesAPI.Core.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
