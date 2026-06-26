using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeController(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees(){
            var employees = _dbcontext.Employees.ToList();

            return Ok(employees);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employees = _dbcontext.Employees.Find(id);

            if(employees is null) {
                return NotFound();
            }


            return Ok(employees);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployeeById(Guid id)
        {
            var employee = _dbcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            _dbcontext.Employees.Remove(employee);
            _dbcontext.SaveChanges();


            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee() { 
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email
            };
            _dbcontext.Employees.Add(employee);
            _dbcontext.SaveChanges();
            return Ok(employee);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateEmployeeById(Guid id,UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _dbcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.Email = updateEmployeeDto.Email;

            _dbcontext.SaveChanges();
            return Ok(employee);
        }
    }
}
