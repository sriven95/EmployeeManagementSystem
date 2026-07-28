using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _dbContext.departments.ToList();

            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddDepartmentDto addDepartmentDto)
        {
            var newDepartment = new Department
            {
                
                DepartmentName = addDepartmentDto.DepartmentName
            };
            _dbContext.departments.Add(newDepartment);
            _dbContext.SaveChanges();
            return Ok(newDepartment);
        }


        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetDepartmentById(Guid Id)
        {
            var department = _dbContext.departments.Find(Id);

            if (department is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(department);
            }
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public IActionResult UpdateDepartmentById(Guid Id, UpdateDepartmentDto updateDepartmentDto)
        {
            var department = _dbContext.departments.Find(Id);

            if (department is null)
            {
                return NotFound();
            }
            else
            {

                department.DepartmentName = updateDepartmentDto.DepartmentName;
                _dbContext.departments.Update(department);
                _dbContext.SaveChanges();
                return Ok(department);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult DeleteDepartmentById(Guid Id)
        {
            var department = _dbContext.departments.Find(Id);

            if (department is null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.departments.Remove(department);
                _dbContext.SaveChanges();
                return Ok(department);
            }
        }
    }
}
