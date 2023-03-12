using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class StudentModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Student>()
                .Property(p => p.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.UserName)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.LastName)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.PasswordValue)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.PhotoUrl)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .IsRequired();
        }
    }
}
