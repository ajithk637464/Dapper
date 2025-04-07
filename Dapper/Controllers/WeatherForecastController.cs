using Dapper.Model;
using Dapper.Services.IService;
using Dapper.Services.ServiceImplementation;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public WeatherForecastController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetEmployeeDetails")]
        public async Task<ActionResult<List<EmployeeDetails>>> Get()
        {
            var result = await _employeeService.GetAll();
            return Ok(result);
        }
        [HttpPost("GetEmployeeById")]
        public async Task<ActionResult<List<EmployeeDetails>>> GetEmpById([FromQuery]int  empId)
        {
            var result = await _employeeService.GetEmpById(empId);
            return Ok(result);
        }
    }
}
