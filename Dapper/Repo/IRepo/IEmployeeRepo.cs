using Dapper.Model;

namespace Dapper.Repo.IRepo
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDetails>> GetAllEmps();
        Task<EmployeeDetails> GetEmployeeById(int empId);
    }
}
