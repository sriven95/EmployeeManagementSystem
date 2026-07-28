using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class EmployeesController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _dbContext.employees.ToList();

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var newEmployee = new Employee
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email,
                DepartmentId = addEmployeeDto.DepartmentId
            };
            _dbContext.employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return Ok(newEmployee);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetEmployeeById(Guid Id)
        {
            var employee = _dbContext.employees.Find(Id);

            if(employee is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public IActionResult UpdateEmployeeById(Guid Id,UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _dbContext.employees.Find(Id);

            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                employee.FirstName = updateEmployeeDto.FirstName;
                employee.LastName = updateEmployeeDto.LastName;
                employee.Email = updateEmployeeDto.Email;
                employee.DepartmentId = updateEmployeeDto.DepartmentId;
                _dbContext.employees.Update(employee);
                _dbContext.SaveChanges();
                return Ok(employee);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult DeleteEmployeeById(Guid Id)
        {
            var employee = _dbContext.employees.Find(Id);

            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.employees.Remove(employee);
                _dbContext.SaveChanges();
                return Ok(employee);
            }
        }


    }
}
