using EmployeesAPI.Core.Mappings;
using System.Numerics;
using EmployeesAPI.Presentation.Models;
using AutoMapper;

namespace EmployeesAPI.Core.Queries.GetDetails
{
    /// <summary>
    /// Класс, описывающий, что будет возвращено
    /// пользователю, когда он запросит детали по сотруднику.
    /// </summary>
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public string? FullName { get; set; }

        public string? Position { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.FullName, opt => opt.MapFrom(employeeVm => employeeVm.FullName))
                .ForMember(employeeVm => employeeVm.Position, opt => opt.MapFrom(employeeVm => employeeVm.Position))
                .ForMember(employeeVm => employeeVm.CreatedDateTime, opt => opt.MapFrom(employeeVm => employeeVm.CreatedDateTime))
                .ForMember(employeeVm => employeeVm.UpdatedDateTime, opt => opt.MapFrom(employeeVm => employeeVm.UpdatedDateTime));
        }
    }
}
