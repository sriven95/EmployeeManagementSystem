using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDepartmentApi.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public ICollection<Employee> employees { get; set; } = new List<Employee>();
    }
}