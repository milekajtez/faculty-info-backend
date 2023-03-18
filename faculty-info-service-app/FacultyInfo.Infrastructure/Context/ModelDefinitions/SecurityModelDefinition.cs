using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class SecurityModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Security>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Security>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Security>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Security>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Security>()
                .Property(e => e.Password)
                .IsRequired();

            modelBuilder.Entity<Security>()
                .Property(e => e.UserType)
                .HasDefaultValue(UserType.MainAdmin)
                .IsRequired();
        }
    }
}
