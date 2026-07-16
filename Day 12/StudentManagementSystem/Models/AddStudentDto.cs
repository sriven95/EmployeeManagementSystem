namespace StudentManagementSystem.Models
{
    public class AddStudentDto
    {
        public Guid StudentId { get; set; }
        public required string? FirstName { get; set; }

        public required string? LastName { get; set; }

        public required string? Email { get; set; }

        public Guid DeparetmentId { get; set; }
    }
}
