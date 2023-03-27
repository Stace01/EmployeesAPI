using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.Presentation.Models
{
    /// <summary>
    /// Базовая модель для будущих сущностей.
    /// </summary>
    public class BaseEntity
    {
        public DateTime CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
