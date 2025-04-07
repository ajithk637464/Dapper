using Dapper.Model;

namespace Dapper.Services.IService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDetails>> GetAll();
        Task<EmployeeDetails> GetEmpById(int empId);
        List<EmployeeDetails> GetAllEmpsUsingQuery();
        EmployeeDetails GetEmployeeWhoWithinSalaryLimit(int salary);
        Task<EmployeeDetails> GetEmployeeWhoWithinSalaryLimitAsync(int salary);
        Task<string> DbReader();
        Task<EmpDept> GetMultipleRows();


    }
}
