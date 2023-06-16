using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class MainAdminModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainAdmin>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.Password)
                .IsRequired();
        }
    }
}
