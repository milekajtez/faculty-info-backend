using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public  class UserModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.DateOfBirth)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<User>()
                .Property(e => e.UserType)
                .IsRequired();
        }
    }
}
