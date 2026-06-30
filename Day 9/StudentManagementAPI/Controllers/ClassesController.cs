using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Models.Entities;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ClassesController(ApplicationDbContext dbContext)
        {

            this._dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllClasses()
        {
            var classes = _dbContext.Classes.ToList();
            return Ok(classes);
        }

        [HttpGet("{Id:Guid}")]
        public IActionResult GetClassById(Guid Id)
        {
            var classEntity = _dbContext.Classes.Find(Id);
            if (classEntity is null)
            {
                return NotFound();
            }

            return Ok(classEntity);

        }

        [HttpDelete("{Id:Guid}")]
        public IActionResult DeleteClassById(Guid Id) {
            var ClassEntity = _dbContext.Classes.Find(Id);
            if(ClassEntity is null)
            {
                return NotFound();
            }
            _dbContext.Classes.Remove(ClassEntity);
            _dbContext.SaveChanges();
            return Ok(ClassEntity);
        }

        [HttpPost]
        public IActionResult AddClass(Guid Id,AddClassDto addClassDto) { 
            var classEntity = new Class()
            {
                ClassName = addClassDto.ClassName
            };

            _dbContext.Classes.Add(classEntity);
            _dbContext.SaveChanges();
            return Ok(classEntity);
        }

        [HttpPut("{Id:Guid}")]
        public IActionResult UpdateClass(Guid Id, UpdateClassDto updateClassDto)
        {
            var classEntity = _dbContext.Classes.Find(Id);
            if (classEntity is null)
            {
                return NotFound();
            }
            classEntity.ClassName = updateClassDto.ClassName;
            _dbContext.SaveChanges();
            return Ok(classEntity);
        }
    }
}   
