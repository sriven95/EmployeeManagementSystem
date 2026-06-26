using EmployeeDepartmentManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentManagementAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
