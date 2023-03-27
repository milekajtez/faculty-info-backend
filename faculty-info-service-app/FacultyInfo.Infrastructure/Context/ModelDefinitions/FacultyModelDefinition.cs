using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class FacultyModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Faculty>()
                .Property(f => f.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Faculty>()
                .Property(f => f.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Faculty>()
                .HasIndex(e => e.Tin)
                .IsUnique();

            modelBuilder.Entity<Faculty>()
                .Property(f => f.Name)
                .IsRequired();

            modelBuilder.Entity<Faculty>()
                .Property(f => f.Description)
                .IsRequired();

            modelBuilder.Entity<Faculty>()
                .Property(f => f.Location)
                .IsRequired();
        }
    }
}
