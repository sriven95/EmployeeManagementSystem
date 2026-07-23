namespace StudentManagementSystem.Models
{
    public class UpdateStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public Guid ClassId { get; set; }
    }
}
