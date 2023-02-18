using FacultyInfo.Domain.Models;
using FacultyInfo.Domain.Models.ModelsForUsers;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class ProfessorModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Professor>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Professor>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Professor>()
                .Property(e => e.UserName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(e => e.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .IsRequired();
            
            modelBuilder.Entity<Professor>()
                .Property(e => e.ProfessorType)
                .IsRequired();
        }
    }
}
