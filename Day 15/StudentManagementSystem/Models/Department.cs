namespace StudentManagementSystem.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
        public ICollection<Employee>? employees { get; set; }
    }
}
