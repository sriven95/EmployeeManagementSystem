namespace StudentManagementSystem.Models
{
    public class UpdateDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
    }
}
