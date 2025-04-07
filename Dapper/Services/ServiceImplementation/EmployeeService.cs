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
    }
}
