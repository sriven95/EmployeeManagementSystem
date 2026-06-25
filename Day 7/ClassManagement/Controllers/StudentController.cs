using ClassManagement.Data;
using ClassManagement.Models;
using ClassManagement.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _dbContext.Students.ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetStudentById(Guid Id)
        {
            var student = _dbContext.Students.Find(Id);

            if (student is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(student);
            }


        }

        [HttpPost]
        public IActionResult AddStudent(StudentDto studentDto)
        {

            var student = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,

            };

            _dbContext.Add(student);
            _dbContext.SaveChanges();

            return Ok(student);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public IActionResult UpdateStudentByID(Guid Id, UpdateStudentDto updateStudentdto)
        {
            var student = _dbContext.Students.Find(Id);

            if (student is null)
            {
                return NotFound();
            }

            student.FirstName = updateStudentdto.FirstName;
            student.LastName = updateStudentdto.LastName;
            student.Email = updateStudentdto.Email;
            

            _dbContext.SaveChanges();

            return Ok(student);
        }


        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult DeleteStudentById(Guid Id)
        {
            var student = _dbContext.Students.Find(Id);
            if (student is null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return Ok(student);
        }
    }
}