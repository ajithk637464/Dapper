using Dapper.Model;
using Dapper.Services.IService;
using Dapper.Services.ServiceImplementation;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
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
        [HttpGet("GetAllUsingQuery")]
        public List<EmployeeDetails> GetAllEmpsUsingQuery()
        {
            var result = _employeeService.GetAllEmpsUsingQuery();
            return result;
        }
        [HttpPost("GetEmployeeWhoWithinSalaryLimit")]
        public EmployeeDetails GetEmployeeWhoWithinSalaryLimit([FromQuery]int salLimit)
        {
            var result = _employeeService.GetEmployeeWhoWithinSalaryLimit(salLimit);
            return result;
        }
        [HttpPost("GetEmployeeWhoWithinSalaryLimitasync")]
        public async Task<EmployeeDetails> GetEmployeeWhoWithinSalaryLimitAsync([FromQuery] int salLimit)
        {
            var result = await _employeeService.GetEmployeeWhoWithinSalaryLimitAsync(salLimit);
            return result;
        }
        [HttpGet("EmployeeNameReader")]
        public async Task<string> EmployeeNameReader()
        {
            var result = await _employeeService.DbReader();
            return result;
        }
        [HttpPost("GetMultipleRows")]
        public async Task<EmpDept> GetMultipleRows()
        {
            return await _employeeService.GetMultipleRows();
        }
    }
}
