using AutoMapper;
using EmployeesAPI.Core.Mappings;
using EmployeesAPI.Presentation.Models;
using System.Numerics;

namespace EmployeesAPI.Core.Queries.GetList
{
    public class EmployeeDTO : IMapWith<Employee>
    {
        public Guid EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDTO>()
                .ForMember(employeeDTO => employeeDTO.EmployeeId, opt => opt.MapFrom(playerDTO => playerDTO.EmployeeId))
                .ForMember(employeeDTO => employeeDTO.FullName, opt => opt.MapFrom(playerDTO => playerDTO.FullName))
                .ForMember(employeeDTO => employeeDTO.Position, opt => opt.MapFrom(playerDTO => playerDTO.Position));
        }
    }
}
