namespace ClassManagement.Models.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }

    }
}
