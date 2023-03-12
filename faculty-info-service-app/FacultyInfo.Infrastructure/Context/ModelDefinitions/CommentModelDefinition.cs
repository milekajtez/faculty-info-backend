using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class CommentModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(c => c.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(c => c.Description)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.FacultyAdmin)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.FacultyAdminId);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Professor)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ProfessorId);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
