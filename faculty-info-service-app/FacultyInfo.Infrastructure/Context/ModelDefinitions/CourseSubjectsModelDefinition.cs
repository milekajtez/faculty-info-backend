using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class CourseSubjectsModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSubjects>()
                .HasKey(cs => new { cs.CourseId, cs.SubjectId });

            modelBuilder.Entity<CourseSubjects>()
                .HasOne(cs => cs.Course)
                .WithMany(cs => cs.CourseSubjects)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseSubjects>()
                .HasOne(cs => cs.Subject)
                .WithMany(cs => cs.CourseSubjects)
                .HasForeignKey(cs => cs.SubjectId);
        }
    }
}
