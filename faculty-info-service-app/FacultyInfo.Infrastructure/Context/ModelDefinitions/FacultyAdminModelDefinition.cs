using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class FacultyAdminModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacultyAdmin>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<FacultyAdmin>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .HasOne(e => e.Faculty)
                .WithMany(e => e.FacultyAdmins)
                .HasForeignKey(e => e.FacultyId);
        }
    }
}
