using Common.Models;

namespace Common.Services.Interfaces
{
    public interface IEmployeeSerice
    {
        List<Employee> GetEmployees();        
        bool AddEmployee(Employee user);
    }
}
