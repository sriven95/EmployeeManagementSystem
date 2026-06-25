using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmployeeController(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var employees = _dbcontext.Employees.ToList();

            return Ok(employees);
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeedto)
        {
            var employeeEntity = new Employee
            {
                FirstName = employeedto.FirstName,
                LastName = employeedto.LastName,
                Email = employeedto.Email
            };

            _dbcontext.Employees.Add(employeeEntity);
            _dbcontext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeByID(Guid id)
        {
            var employee =_dbcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateEmployeeByID(Guid id, UpdateEmployeeDto employeeDto)
        {
            var employee = _dbcontext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;

            _dbcontext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployeeByID(Guid id)
        {
            var employee = _dbcontext.Employees.Find(id);
            
            if(employee is null) { 
                return NotFound();
            }

            _dbcontext.Employees.Remove(employee);
            _dbcontext.SaveChanges();

            return Ok(employee);

        }
    }
}
