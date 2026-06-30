namespace StudentManagementAPI.Models.Entities
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }

        public ICollection<Student>? Students { get; set; }

    }
}
