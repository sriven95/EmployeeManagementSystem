using EmployeeDepartmentManagementAPI.Data;
using EmployeeDepartmentManagementAPI.Models;
using EmployeeDepartmentManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public DepartmentsController(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _dbcontext.departments.ToList();
            return Ok(departments);
        }

        [HttpGet("{Id:guid}")]
        public IActionResult GetDepartmentById(Guid Id)
        {
            var department = _dbcontext.departments.Find(Id);
            if (department is null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpDelete("{Id:guid}")]
        public IActionResult DeleteDepartmentById(Guid Id)
        {
            var department = _dbcontext.departments.Find(Id);
            if (department is null)
            {
                return NotFound();
            }
            _dbcontext.departments.Remove(department);
            _dbcontext.SaveChanges();
            return Ok(department);
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto adddepartmentdto)
        {
            var department = new Department
            {
                DepartmentName = adddepartmentdto.DepartmentName
            };

            _dbcontext.departments.Add(department);
            _dbcontext.SaveChanges();

            return Ok(department);
        }
        [HttpPut("{Id:guid}")]
        public IActionResult UpdateDepartmentByID(Guid Id, UpdateDepartmentDto updateDepartmentDto)
        {
            var department = _dbcontext.departments.Find(Id);
            if (department is null)
            {
                return NotFound();
            }
            department.DepartmentName = updateDepartmentDto.DepartmentName;
            _dbcontext.SaveChanges();
            return Ok(department);
        }
    }
}
