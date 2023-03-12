using FacultyInfo.Domain.Enums.Attachment;
using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class AttachmentModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Attachment>()
                .Property(a => a.Created)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(a => a.Updated)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(a => a.OriginalName)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(a => a.Url)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(a => a.AttachmentType)
                .HasDefaultValue(AttachmentType.Other)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .HasOne(e => e.Post)
                .WithMany(e => e.Attachments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attachment>()
                .HasOne(e => e.Comment)
                .WithMany(e => e.Attachments)
                .HasForeignKey(e => e.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
