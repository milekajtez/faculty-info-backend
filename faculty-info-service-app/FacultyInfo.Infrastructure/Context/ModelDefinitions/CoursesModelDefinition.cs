using FacultyInfo.Domain.Enums.Course;
using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class CoursesModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Course>()
                .Property(c => c.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.DepartmentName)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.DepartmentInfo)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseType)
                .HasDefaultValue(CourseType.Bachelor)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .HasOne(e => e.Faculty)
                .WithMany(e => e.Courses)
                .HasForeignKey(e => e.FacultyId);
        }
    }
}
