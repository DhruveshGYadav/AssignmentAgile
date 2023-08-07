using Common.Models;
using Common.Repositories.Interfaces;
using Common.Services.Interfaces;

namespace Common.Services
{
    public class EmployeeService : IEmployeeSerice
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }
        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
    }
}
