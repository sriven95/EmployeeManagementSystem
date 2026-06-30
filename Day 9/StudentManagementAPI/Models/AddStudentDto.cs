namespace StudentManagementAPI.Models
{
    public class AddStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public Guid ClassId { get; set; }
    }
}
