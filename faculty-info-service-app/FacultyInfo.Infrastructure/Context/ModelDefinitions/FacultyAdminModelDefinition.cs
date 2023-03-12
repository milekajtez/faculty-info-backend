using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class FacultyAdminModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacultyAdmin>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.UserName)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.Email)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.FirstName)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.LastName)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.PasswordValue)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .Property(f => f.PhotoUrl)
                .IsRequired();

            modelBuilder.Entity<FacultyAdmin>()
                .HasOne(fa => fa.Faculty)
                .WithMany(fa => fa.FacultyAdmins)
                .HasForeignKey(fa => fa.FacultyId);
        }
    }
}
