namespace EmployeeManagementAPI.Models.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }

    }
}
