using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;

        public Student? Student { get; set; }

        public Course? Course { get; set; }
    }
}
