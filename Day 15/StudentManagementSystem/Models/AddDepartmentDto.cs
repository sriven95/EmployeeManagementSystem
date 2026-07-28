namespace StudentManagementSystem.Models
{
    public class AddDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
    }
}
