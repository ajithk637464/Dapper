using Dapper.Model;
using Dapper.Model.Data;
using Dapper.Repo.IRepo;
using Dapper;
using System.Data;
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
            using (var connection = this.context.CreateConnection())
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
    }
}
