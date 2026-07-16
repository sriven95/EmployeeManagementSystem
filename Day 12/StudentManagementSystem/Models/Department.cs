namespace StudentManagementSystem.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public required ICollection<Student>? students { get; set; } = new List<Student>();
    }
}
