using SchoolManagement.DTOs;

using SchoolManagement.Middlewares;
using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services.Interfaces;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolManagement.Services
{
    public class StudentService(IStudentRepository repo) : IStudentService
    {
        private static StudentDto ToDto(Student s) => new()
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            EnrollmentDate = s.EnrollmentDate,
            TotalCourses = s.Enrollments.Count
        };

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await repo.GetAllAsync();
            return students.Select(ToDto);
        }
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await repo.GetByIdAsync(id);
            return student is null ? null : ToDto(student);
        }

        public async Task<StudentDto> CreateAsync(CreateStudentDto dto)
        {
            if (await repo.EmailExistsAsync(dto.Email))
                throw new AppException($"Email '{dto.Email}' is already registered.", 400);

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                EnrollmentDate = DateTime.UtcNow
            };  

            var created = await repo.CreateAsync(student);

            return ToDto(created);
        }
        public async Task<StudentDto> UpdateAsync(int id, CreateStudentDto dto)
        {
            if (await repo.EmailExistsAsync(dto.Email, id))
                throw new AppException($"Email '{dto.Email}' is used by another student.", 400);
            var updated = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
            
            };
            var result = await repo.UpdateAsync(id, updated);

            if (result is null)
                throw new AppException("Student not found.", 404);

            return ToDto(result);
        }
        public async Task DeleteAsync(int id)
        {
            var deleted = await repo.DeleteAsync(id);

            if (!deleted)
                throw new AppException("Student not found.", 404);
        }
        public async Task<StudentDto?> GetByEmailAsync(string email)
        {
            var s = await repo.GetByEmailAsync(email);
            return s is null ? null : ToDto(s);
        }


    }
}
