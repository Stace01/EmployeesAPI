using AutoMapper;
using EmployeesAPI.Infrastructure.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using EmployeesAPI.Core.Queries.GetList;
using EmployeesAPI.Core.Queries.GetDetails;
using EmployeesAPI.Core.Commands;

namespace EmployeesAPI.Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmployeesController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получаем данные всех сотрудников.
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetEmployee")]
        public async Task<ActionResult<EmployeelistVm>> GetAllEmployees()
        {
            Log.Information("Получение всех сотрудников...");

            var query = new GetEmployeelistQuery
            {
                EmployeeId = EmployeeId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получаем данные сотрудника.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{name}")]
        public async Task<ActionResult<EmployeeDetailsVm>> GetEmployeeData(string name)
        {
            Log.Information("Получение сотрудника по его имени: {Id}", name);

            var query = new GetEmployeeDetailsQuery
            {
                EmployeeId = EmployeeId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Добавляем нового сотрудника.
        /// Атрибут "[FromBody]" указывает,
        /// что параметр метода контроллера должен
        /// быть извлечён из данных тела
        /// HTTP запроса и затем, сериализован.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EmployeelistVm>> AddNewEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(employeeDTO);
            command.FullName = employeeDTO.FullName;
            command.Position = employeeDTO.Position;
            var employeeName = await Mediator.Send(command);
            return Ok(employeeName);
        }

        /// <summary>
        /// Обновляем данные сотрудника.
        /// </summary> 
        /// <param name="EmployeeData"></param>
        /// <returns></returns>
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeData([FromBody] EmployeeDTO employeeDTO)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(employeeDTO);

            try
            {
                //command.FullName = employeeDTO.FullName;
                command.Position = employeeDTO.Position;
                await Mediator.Send(command);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Employees.Any(p => p.EmployeeId == employeeDTO.EmployeeId) is false)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Удаляем сотрудника.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(string name, string position, Guid employeeId)
        {
            var player = await _context.Employees.FindAsync(name);

            var command = new DeleteEmployeeCommand
            {
                EmployeeId = employeeId,
                FullName = name,
                Position = position
            };

            if (player is null)
            {
                Log.Information("Сотрудник не найден");
                return NotFound();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
