using ClassManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassManagementAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> students  { get; set; }
    }
}
