using Dapper.Model;
using Dapper.Model.Data;
using Dapper.Repo.IRepo;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
    
namespace Dapper.Repo.RepoImplementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDBContext context;
        public EmployeeRepo(DapperDBContext dapperDBContext) 
        {
            context = dapperDBContext;
        }

        public async Task<List<EmployeeDetails>> GetAllEmps()
        {
            using (var connection = this.context.CreateConnection())
            {
                string query = "select * from EmployeeDetails";
                var empList = await connection.QueryAsync<EmployeeDetails>(query);
                return empList.ToList();
            }
        }
        public async Task<EmployeeDetails> GetEmployeeById(int empId)
        {
            using (var connection = context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id",empId, DbType.Int32,ParameterDirection.Input);
                var result = await connection.QueryFirstOrDefaultAsync<EmployeeDetails>
                    (
                        "[dbo].[GetEmployeeById]",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                return result;
            }
        }
        public List<EmployeeDetails> GetAllEmpsUsingQuery()
        {
            using (var connection = context.CreateConnection())
            {
                var result = connection.Query<EmployeeDetails>("SELECT * FROM EmployeeDetails");
                return result.ToList();
            }
        }
        public  EmployeeDetails GetEmployeeWhoWithinSalaryLimit(int salary)
        {
            using (var connection = context.CreateConnection())
            {
                var query = "SELECT * FROM EmployeeDetails WHERE Salary > @sal";
                var result = connection.QueryFirst<EmployeeDetails>(query, new { sal = salary});
                return result;
            }
        }
        public async Task<EmployeeDetails> GetEmployeeWhoWithinSalaryLimitAsync(int salary)
        {
            using (var connection = context.CreateConnection())
            {
                var query = "SELECT * FROM EmployeeDetails WHERE Salary > @sal";
                var result = await connection.QueryFirstAsync<EmployeeDetails>(query, new { sal = salary });
                return result;
            }
        }
        public async Task<string> DbReader()
        {
            using (var connection = context.CreateConnection())
            {
                using (var reader = await connection.ExecuteReaderAsync("SELECT * FROM EmployeeDetails"))
                {
                    while (reader.Read())
                    {
                        string firstName = reader["FirstName"].ToString();
                        Console.WriteLine(firstName);
                    }
                }
            }
            return "ok";
        }
        public async Task<EmpDept> GetMultipleRows()
        {
            using (var connection = context.CreateConnection())
            {
                var sql = @"SELECT * FROM EmployeeDetails;
                            SELECT * FROM Departments;";
                using (var multi = await connection.QueryMultipleAsync(sql))
                {
                    var empList = (await multi.ReadAsync<EmployeeDetails>()).ToList();
                    var deptList = (await multi.ReadAsync<Department>()).ToList();
                    return new EmpDept() { emps = empList, depts = deptList };
                }
            }
        }
    }
}
