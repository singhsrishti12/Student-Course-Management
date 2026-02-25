using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
          
            if (!await context.Courses.AnyAsync())
            {
                var courses = new List<Course>
                {
                    new Course { Name = "Data Structures", Code = "DS1", Credits = 4 },
                    new Course { Name = "Web Development", Code = "WD11", Credits = 3 },
                    new Course { Name = "Calculus I", Code = "CA1", Credits = 4 }
                };

                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }

          
            if (!await context.Students.AnyAsync())
            {
                var students = new List<Student>
                {
                    new Student { Name = "Arjun Sharma", Email = "arjun@stu.com" },
                    new Student { Name = "Priya Patel", Email = "priya@stu.com" },
                    new Student { Name = "Ravi Kumar", Email = "ravi@stu.com" }
                };

                await context.Students.AddRangeAsync(students);
                await context.SaveChangesAsync();
            }

            if (!await context.Enrollments.AnyAsync())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment { StudentId = 1, CourseId = 1 },
                    new Enrollment { StudentId = 1, CourseId = 2 },
                    new Enrollment { StudentId = 2, CourseId = 3 }
                };

                await context.Enrollments.AddRangeAsync(enrollments);
                await context.SaveChangesAsync();
            }
        }
    }
}
