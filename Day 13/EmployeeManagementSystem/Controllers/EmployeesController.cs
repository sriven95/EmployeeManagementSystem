using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
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
            var Employees = _dbContext.employees.ToList();

            return Ok(Employees);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetEmployeesById(Guid Id)
        {
            var Employees = _dbContext.employees.Find(Id);

            if(Employees is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Employees);
            }

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var Employee = new Employee
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email,
                DepartmentId = addEmployeeDto.DepartmentId
            };

            _dbContext.employees.Add(Employee);
            _dbContext.SaveChanges();

            return Ok(Employee);


        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult DeleteEmployeeById(Guid Id)
        {
            var Employees = _dbContext.employees.Find(Id);

            if (Employees is null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.employees.Remove(Employees);
                _dbContext.SaveChanges();
                return Ok(Employees);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployeeByID(UpdateEmployeeDto updateEmployeeDto)
        {
            var Employee = new Employee
            {
                FirstName = updateEmployeeDto.FirstName,
                LastName = updateEmployeeDto.LastName,
                Email = updateEmployeeDto.Email,
                DepartmentId = updateEmployeeDto.DepartmentId
            };

            _dbContext.employees.Update(Employee);
            _dbContext.SaveChanges();

            return Ok(Employee);

        }

    }
}
