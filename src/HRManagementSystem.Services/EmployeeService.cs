using HRManagementSystem.Core.Entities;
using HRManagementSystem.Data;

namespace HRManagementSystem.Services
{
    // Employee Service Interface
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }

    // Employee Service Implementation
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            // Validation logic
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            // Set default hire date and status
            employee.HireDate = DateTime.UtcNow;
            employee.Status = EmploymentStatus.Active;
            employee.CreatedAt = DateTime.UtcNow;

            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            employee.UpdatedAt = DateTime.UtcNow;
            await _employeeRepository.UpdateAsync(employee);
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await _employeeRepository.DeleteAsync(employeeId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
    }

    // Similar services for LeaveRequest, Performance, Payroll
}
