using FacultyInfo.Domain.Models.ModelsForUsers;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class DepartmentAdminModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentAdmin>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.UserName)
                .IsRequired();

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<DepartmentAdmin>()
                .Property(e => e.DateOfBirth)
                .HasColumnType("timestamp without time zone")
                .IsRequired();
        }
    }
}
