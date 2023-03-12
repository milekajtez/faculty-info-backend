using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class LikeModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Like>()
                .Property(f => f.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Like>()
                .Property(f => f.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Like>()
                .HasOne(e => e.Post)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(e => e.Comment)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(e => e.FacultyAdmin)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.FacultyAdminId);

            modelBuilder.Entity<Like>()
                .HasOne(e => e.Professor)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.ProfessorId);

            modelBuilder.Entity<Like>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Likes)
                .HasForeignKey(e => e.StudentId);
        }
    }
}
