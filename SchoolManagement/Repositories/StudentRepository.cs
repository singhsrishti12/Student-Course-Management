using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories
{
    public class StudentRepository(AppDbContext db) : IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await db.Students
                            .Include(s => s.Enrollments)
                            .ToListAsync();
        }
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await db.Students
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student?> CreateAsync(Student st)
        {
            db.Students.Add(st);
            await db.SaveChangesAsync();
            return st;
        }
        public async Task<Student?> UpdateAsync(int id, Student updated)
        {
            var existing = await db.Students.FindAsync(id);
            if (existing is null) return null;

            existing.Name = updated.Name;
            existing.Email = updated.Email;

            await db.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student is null) return false;

            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await db.Students
                  .Include(s => s.Enrollments)
                  .FirstOrDefaultAsync(s => s.Email.ToLower() == email.ToLower());

        }
        public async Task<bool> EmailExistsAsync(string email, int excludeId = 0)
        {
            return await db.Students
                   .AnyAsync(s => s.Email.ToLower() == email.ToLower() && s.Id != excludeId);
        }
    }
}
