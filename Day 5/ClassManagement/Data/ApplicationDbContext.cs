using ClassManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Student> students { get; set; } 

    }
}
