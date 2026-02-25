using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.DTOs
{
    public class CreateStudentDto
    {
        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }
    }
}
