namespace StudentManagementSystem.Models
{
    public class UpdateClassDto
    {
        public required string ClassName { get; set; }

        public ICollection<Student>? Students;
    }
}
