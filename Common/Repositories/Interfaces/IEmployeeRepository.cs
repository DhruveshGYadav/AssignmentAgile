using Common.Models;

namespace Common.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        bool AddEmployee(Employee employee);
    }
}
