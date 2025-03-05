using HRManagementSystem.Models;
using HRManagementSystem.Data;
using System.Threading.Tasks;

namespace HRManagementSystem.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            // Add validation and business logic
            return await _employeeRepository.AddAsync(employee);
        }

        // Implement other service methods
    }
}
