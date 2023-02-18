using FacultyInfo.Domain.Models.ModelsForUsers;
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
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.UserName)
                .IsRequired();

            modelBuilder.Entity<MainAdmin>()
                .Property(e => e.Email)
                .IsRequired();
        }
    }
}
