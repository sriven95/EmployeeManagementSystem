using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDepartmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}