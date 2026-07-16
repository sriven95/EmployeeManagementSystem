using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var Students = _dbContext.Students.ToList();

            return Ok(Students);
        }

        [HttpGet("{Id:Guid}")]
        public IActionResult GetStudentById(Guid Id)
        {
            var StudentId = _dbContext.Students.Find(Id);

            if(StudentId is null)
            {
                return NotFound("Student is Not There");
            }

            else
            {
                return Ok(StudentId);

            }

     
        }

      

        [HttpDelete("{Id:Guid}")]
        public IActionResult DeleteStudentById(Guid Id)
        {
            var Student = _dbContext.Students.Find(Id);

            if (Student is null)
            {
                return NotFound("Student is Not There");
            }

            else
            {
                _dbContext.Students.Remove(Student);
                _dbContext.SaveChanges();

                return Ok("Deleted Student"+Student);

            }


        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDto studentDto)
        {
            var Student = new Student()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                DeparetmentId = studentDto.DeparetmentId
            };

            _dbContext.Add(Student);
            _dbContext.SaveChanges();

            return Ok(Student);

        }

        [HttpPut("{Id:Guid}")]
        public IActionResult UpdateStudentById(Guid Id, UpdateStudentDto updateStudentDto)
        {
            var Student = _dbContext.Students.Find();

            if (Student is null)
            {
                return NotFound("Student is Not There");
            }

            else
            {
                Student.FirstName = updateStudentDto.FirstName;
                Student.LastName = updateStudentDto.LastName;
                Student.Email = updateStudentDto.Email;
                Student.DeparetmentId = updateStudentDto.DeparetmentId;

                _dbContext.Students.Update(Student);
                _dbContext.SaveChanges();

                return Ok(Student);

            }
            
        }




    }
}
