using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        { }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasIndex(r => r.Email)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .HasOne(r => r.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Enrollment>()
               .HasOne(r => r.Course)
               .WithMany(e => e.Enrollments)
               .HasForeignKey(r => r.CourseId);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(r => new { r.StudentId, r.CourseId })
                .IsUnique();

        }

        
    }
}
