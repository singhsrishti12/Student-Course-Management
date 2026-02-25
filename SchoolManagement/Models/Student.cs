using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Student
    {
        [Key] 
        public int Id { get; set; }

        [Required,MinLength(2),MaxLength(100)]
        public string Name { get; set; }

        [Required,EmailAddress,MaxLength(150)]
        public string Email { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public ICollection<Enrollment> Enrollments { get; set; } = [];


    }
}
