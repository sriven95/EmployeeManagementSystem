using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Models.Entities;
namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _dbContext.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{Id:Guid}")]
        public IActionResult GetStudent(Guid Id)
        {
            var studentEntity = _dbContext.Students.Find(Id);
            if (studentEntity is null)
            {
                return NotFound();
            }
            return Ok(studentEntity);
        }

        [HttpDelete("{Id:Guid}")]
        public IActionResult DeleteStudent(Guid Id)
        {
            var studentEntity = _dbContext.Students.Find(Id);
            if (studentEntity is null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(studentEntity);
            _dbContext.SaveChanges();
            return Ok(studentEntity);
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            var studentEntity = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                Email = addStudentDto.Email,
                ClassId = addStudentDto.ClassId
            };
            _dbContext.Students.Add(studentEntity);
            _dbContext.SaveChanges();
            return Ok(studentEntity);
        }

        [HttpPut("{Id:Guid}")]
        public IActionResult UpdateStudent(Guid Id, UpdateStudentDto updateStudentDto)
        {
            var studentEntity = _dbContext.Students.Find(Id);
            if (studentEntity is null)
            {
                return NotFound();
            }
            studentEntity.FirstName = updateStudentDto.FirstName;
            studentEntity.LastName = updateStudentDto.LastName;
            studentEntity.Email = updateStudentDto.Email;
            _dbContext.Students.Update(studentEntity);
            _dbContext.SaveChanges();
            return Ok(studentEntity);
        }

    }
}
