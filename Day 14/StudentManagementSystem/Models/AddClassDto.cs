namespace StudentManagementSystem.Models
{
    public class AddClassDto
    {
        public required string ClassName { get; set; }

        public ICollection<Student>? Students;
    }
}
