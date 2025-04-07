using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace Dapper.Model
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string? Department { get; set; }
        public decimal? Salary { get; set; }
    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? Location { get; set; }
    }
    public class EmpDept
    {
        public List<EmployeeDetails> emps { get;set; }
        public List<Department> depts { get; set; }

    }
}
