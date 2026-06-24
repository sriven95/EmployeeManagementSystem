using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext DbContext)
        {
            dbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var allEmployees =  dbContext.Employee.ToList();

            return Ok(allEmployees);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee() {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email
            };

            dbContext.Employee.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);

        }
    }
}
