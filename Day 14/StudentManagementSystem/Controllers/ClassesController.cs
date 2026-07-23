using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClassesController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllClasses() {

            var Classes = _dbContext.Classes.ToList();

            return Ok(Classes);
        
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetClassById(Guid Id)
        {

            var Class = _dbContext.Classes.Find(Id);

            if(Class is null)
            {
                return NotFound();
            }

            else
            {
                return Ok(Class);

            }
        }

        [HttpPost]
        public IActionResult AddClass(AddClassDto addClassDto)
        {
            var newclass = new Class()
            {
                ClassName = addClassDto.ClassName
            };

            _dbContext.Classes.Add(newclass);
            _dbContext.SaveChanges();

            return Ok(newclass);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public IActionResult UpdateClassById(Guid Id,UpdateClassDto updateClassDto)
        {

            var Class = _dbContext.Classes.Find(Id);

            if (Class is null)
            {
                return NotFound();
            }

            else
            {
                Class.ClassName = updateClassDto.ClassName;
                _dbContext.Classes.Update(Class);
                _dbContext.SaveChanges();

                return Ok(Class);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult DeleteClassById(Guid Id)
        {

            var Class = _dbContext.Classes.Find(Id);

            if (Class is null)
            {
                return NotFound();
            }

            else
            {
                _dbContext.Classes.Remove(Class);
                _dbContext.SaveChanges();


                return Ok(Class);

            }
        }
    }
}
