namespace SchoolManagement.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime EnrollmentDate { get; set; }
        public int TotalCourses { get; set; }
    }
}
