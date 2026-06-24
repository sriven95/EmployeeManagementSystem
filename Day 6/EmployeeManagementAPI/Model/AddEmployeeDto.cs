namespace EmployeeManagementAPI.Model
{
    public class AddEmployeeDto
    {
        public Guid EmployeeID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
    }
}
