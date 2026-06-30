using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models.Entities;

namespace StudentManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }

        public DbSet<Student> Students
        {
            get; set;
        }
    }
}
