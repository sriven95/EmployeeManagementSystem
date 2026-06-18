using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDepartmentApi.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
    }
}