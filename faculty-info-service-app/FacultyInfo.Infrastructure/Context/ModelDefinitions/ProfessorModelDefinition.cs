using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class ProfessorModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Professor>()
                .Property(p => p.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.UserName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.LastName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.PasswordValue)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.PhotoUrl)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.PhotoUrl)
                .HasDefaultValue(ProfessorType.Regular)
                .IsRequired();
        }
    }
}
