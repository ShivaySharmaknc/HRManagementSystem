using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.Services;
using HRManagementSystem.ViewModels;
using AutoMapper;

namespace HRManagementSystem.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var employeeVMs = _mapper.Map<IEnumerable<EmployeeDetailsViewModel>>(employees);
            return View(employeeVMs);
        }

        // Add other action methods for CRUD operations
    }
}
