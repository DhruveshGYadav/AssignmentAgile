using Common.Models;
using Common.Repositories.Interfaces;

using Dapper;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Common.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AssignmentAIContext _context;
        private readonly SqlConnection DbConnection;

        public EmployeeRepository(AssignmentAIContext context, IConfiguration configuration)
        {
            _context = context;
            DbConnection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }

        public bool AddEmployee(Employee objEmployee)
        {
            var obj = new
            {
                EmployeeCode = objEmployee.EmployeeCode,
                Name = objEmployee.Name,
                MobileNo = objEmployee.MobileNo,
                DOB = objEmployee.DOB,
                Gender = objEmployee.Gender,
                Photo = objEmployee.Photo,
            };

            var res = DbConnection.Execute("AddEmployeeSP", obj, commandType: System.Data.CommandType.StoredProcedure);
            return res == 1;
        }        

        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }       
    }
}
