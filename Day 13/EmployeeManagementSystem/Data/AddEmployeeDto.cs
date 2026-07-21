namespace EmployeeManagementSystem.Data
{
    public class AddEmployeeDto
    {

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public Guid DepartmentId { get; set; }

    }
}
