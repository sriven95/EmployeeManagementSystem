namespace EmployeeManagementSystem.Data
{
    public class UpdateEmployeeDto
    {
        public Guid EmployeeId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
