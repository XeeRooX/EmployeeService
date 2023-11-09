using EmployeeService.Commands;
using EmployeeService.Dtos;
using EmployeeService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IEmployeeCommands _employeeCommands;
        private readonly IEmployeeQueries _employeeQueries;
        public EmployeeController(IEmployeeCommands employeeCommands, IEmployeeQueries employeeQueries)
        {
            _employeeCommands = employeeCommands;
            _employeeQueries = employeeQueries;
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(EmployeeGetDto input)
        {
            var result = await _employeeQueries.GetEmployeeAsync(input);
            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeQueries.GetAllEmployeesAsync();
            return new JsonResult(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EmployeeEditDto input)
        {
            await _employeeCommands.EditEmployeeAsync(input);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EmployeeAddDto input)
        {
            var id = await _employeeCommands.AddEmployeeAsync(input);
            return new JsonResult(new {id});
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(EmployeeGetDto input)
        {
            await _employeeCommands.DeleteEmployeeAsync(input);
            return Ok();
        }
    }
}
