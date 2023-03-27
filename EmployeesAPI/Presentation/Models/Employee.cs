namespace EmployeesAPI.Presentation.Models
{
    public class Employee : BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }
    }
}
