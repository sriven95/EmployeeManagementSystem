using EmployeeDepartmentManagementAPI.Data;
using EmployeeDepartmentManagementAPI.Models;
using EmployeeDepartmentManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmployeesController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _dbcontext.employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbcontext.employees.Find(id);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeById(Guid id)
        {
            var employee = _dbcontext.employees.Find(id);
            if (employee is null)
                return NotFound();

            _dbcontext.employees.Remove(employee);
            _dbcontext.SaveChanges();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            
            var employee = new Employee
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email,
                DepartmentId = addEmployeeDto.DepartmentId
            };
            _dbcontext.employees.Add(employee);
            _dbcontext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeById(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _dbcontext.employees.Find(id);
            if (employee is null)
                return NotFound();

            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.Email = updateEmployeeDto.Email;
            employee.DepartmentId = updateEmployeeDto.DepartmentId;

            _dbcontext.SaveChanges();
            return Ok(employee);
        }
    }
}
