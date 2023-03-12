using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class MainAdminModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainAdmin>()
                .HasKey(ma => ma.Id);

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.UserName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.Email)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.FirstName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.LastName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(ma => ma.PasswordValue)
                .IsRequired();
        }
    }
}
