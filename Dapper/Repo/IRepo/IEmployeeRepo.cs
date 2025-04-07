using Dapper.Model;

namespace Dapper.Repo.IRepo
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDetails>> GetAllEmps();
        Task<EmployeeDetails> GetEmployeeById(int empId);
        List<EmployeeDetails> GetAllEmpsUsingQuery();
        EmployeeDetails GetEmployeeWhoWithinSalaryLimit(int salary);
        Task<EmployeeDetails> GetEmployeeWhoWithinSalaryLimitAsync(int salary);
        Task<string> DbReader();
        Task<EmpDept> GetMultipleRows();


    }
}
