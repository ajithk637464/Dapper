using Dapper.Model;
using Dapper.Repo.IRepo;
using Dapper.Repo.RepoImplementation;
using Dapper.Services.IService;

namespace Dapper.Services.ServiceImplementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo; 
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<List<EmployeeDetails>> GetAll()
        {
            var result = await _employeeRepo.GetAllEmps();
            return result;
        }
        public async Task<EmployeeDetails> GetEmpById(int empId)
        {
            return await _employeeRepo.GetEmployeeById(empId);
        }
        public List<EmployeeDetails> GetAllEmpsUsingQuery()
        {
            return _employeeRepo.GetAllEmpsUsingQuery();
        }
        public EmployeeDetails GetEmployeeWhoWithinSalaryLimit(int salary)
        {
            return _employeeRepo.GetEmployeeWhoWithinSalaryLimit(salary);
        }
        public Task<EmployeeDetails> GetEmployeeWhoWithinSalaryLimitAsync(int salary)
        {
            return _employeeRepo.GetEmployeeWhoWithinSalaryLimitAsync(salary);
        }
        public async Task<string> DbReader()
        {
            return await _employeeRepo.DbReader();
        }
        public async Task<EmpDept> GetMultipleRows()
        {
            return await _employeeRepo.GetMultipleRows();
        }

    }
}
