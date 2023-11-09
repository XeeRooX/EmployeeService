using EmployeeService.Commands;
using EmployeeService.Dtos;
using EmployeeService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class DepartmentController : ApiBaseController
    {
        private readonly IDepartmentCommands _departmentCommands;
        private readonly IDepartmentQueries _departmentQueries;
        public DepartmentController(IDepartmentCommands departmentCommands, IDepartmentQueries departmentQueries)
        {
            _departmentCommands = departmentCommands;
            _departmentQueries = departmentQueries;
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(DepartmentGetDto input)
        {
            var result = await _departmentQueries.GetDepartmentAsync(input);
            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentQueries.GetAllDepartmentsAsync();
            return new JsonResult(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(DepartmentEditDto input)
        {
            await _departmentCommands.EditDepartmentAsync(input);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DepartmentAddDto input)
        {
            var id = await _departmentCommands.AddDepartmentAsync(input);
            return new JsonResult(new { id });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DepartmentGetDto input)
        {
            await _departmentCommands.DeleteDepartmentAsync(input);
            return Ok();
        }
    }
}
