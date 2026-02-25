using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required,MinLength(2),MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(5)]
        public string Code { get; set; }

        [Required,Range(1,4)]
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
