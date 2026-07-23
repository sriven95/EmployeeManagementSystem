using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
        [ApiController]
        [Route("api/[Controller]")]
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

                var students = _dbContext.Students.ToList();

                return Ok(students);

            }

            [HttpGet]
            [Route("{Id:Guid}")]
            public IActionResult GetstudentById(Guid Id)
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
            public IActionResult AddStudent(AddStudentDto addStudentDto)
            {
                var newStudent = new Student()
                {
                    FirstName = addStudentDto.FirstName,
                    LastName = addStudentDto.LastName,
                    Email = addStudentDto.Email,
                    ClassId = addStudentDto.ClassId

                };

                _dbContext.Students.Add(newStudent);
                _dbContext.SaveChanges();

                return Ok(newStudent);
            }

            [HttpPut]
            [Route("{Id:Guid}")]
            public IActionResult UpdateStudentById(Guid Id, UpdateStudentDto updateStudentDto)
            {

                var UpdatedStudent = _dbContext.Students.Find(Id);

                if (UpdatedStudent is null)
                {
                    return NotFound();
                }

                else
                {
                    UpdatedStudent.FirstName = updateStudentDto.FirstName;
                    UpdatedStudent.LastName = updateStudentDto.LastName;
                    UpdatedStudent.Email = updateStudentDto.Email;
                    UpdatedStudent.ClassId = updateStudentDto.ClassId;

                    _dbContext.Students.Update(UpdatedStudent);
                    _dbContext.SaveChanges();

                    return Ok(UpdatedStudent);
                }
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

                else
                {
                    _dbContext.Students.Remove(student);
                    _dbContext.SaveChanges();


                    return Ok(student);

                }
            }
        }
    }

