using Dapper.Model;

namespace Dapper.Services.IService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDetails>> GetAll();
        Task<EmployeeDetails> GetEmpById(int empId);
    }
}
