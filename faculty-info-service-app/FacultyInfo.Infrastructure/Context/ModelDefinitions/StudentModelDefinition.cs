using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class StudentModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Student>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(e => e.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .IsRequired();
        }
    }
}
