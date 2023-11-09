using EmployeeService.Commands;
using EmployeeService.Dtos;
using EmployeeService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class PositionController : ApiBaseController
    {
        private readonly IPositionCommands _positionCommands;
        private readonly IPositionQueries _positionQueries;
        public PositionController(IPositionCommands positionCommands, IPositionQueries positionQueries) 
        {
            _positionCommands = positionCommands;
            _positionQueries = positionQueries;
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(PositionGetDto input)
        {
            var result = await _positionQueries.GetPositionAsync(input);
            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _positionQueries.GetAllPositionsAsync();
            return new JsonResult(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(PositionEditDto input)
        {
            await _positionCommands.EditPositionAsync(input);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PositionAddDto input)
        {
            var id = await _positionCommands.AddPositionAsync(input);
            return new JsonResult(new { id });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(PositionGetDto input)
        {
            await _positionCommands.DeletePositionAsync(input);
            return Ok();
        }
    }
}
