using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ApiBaseController : ControllerBase
    {
    }
}
