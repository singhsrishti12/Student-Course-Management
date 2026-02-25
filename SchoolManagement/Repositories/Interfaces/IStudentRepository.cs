using SchoolManagement.Models;

namespace SchoolManagement.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> CreateAsync(Student st);
        Task<Student?> UpdateAsync(int id, Student st);
        Task<bool> DeleteAsync(int id);
        Task<Student?> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email, int excludeId = 0);
    }
}
