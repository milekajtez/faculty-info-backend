using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class CourseStudentsModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Course)
                .WithMany(cs => cs.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(cs => cs.Student)
                .WithMany(cs => cs.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);
        }
    }
}
