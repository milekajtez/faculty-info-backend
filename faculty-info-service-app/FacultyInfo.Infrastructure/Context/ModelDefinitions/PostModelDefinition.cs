using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class PostModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .Property(p => p.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Description)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Subject)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.SubjectId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.FacultyAdmin)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.FacultyAdminId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Professor)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.ProfessorId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Student)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.StudentId);
        }
    }
}
