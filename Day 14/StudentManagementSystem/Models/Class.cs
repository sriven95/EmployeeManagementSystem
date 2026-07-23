namespace StudentManagementSystem.Models
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public required string ClassName { get; set; }

        public ICollection<Student>? Students;

    }
}
