using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        public EmployeeController()
        {
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Content("ok");
        }
    }
}
