using ClassManagementAPI.Data;
using ClassManagementAPI.Models;
using ClassManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public StudentController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allstudents = _dbcontext.students.ToList();
            return Ok(allstudents);
        }
        [HttpPost]
        public IActionResult AddStudent(EmployeeDto employeedto)
        {
            var student = new Student { FirstName = employeedto.FirstName, LastName = employeedto.LastName, Email = employeedto.Email };
            _dbcontext.Add(student);
            _dbcontext.SaveChanges();

            return Ok(student);
        }
    }
}
