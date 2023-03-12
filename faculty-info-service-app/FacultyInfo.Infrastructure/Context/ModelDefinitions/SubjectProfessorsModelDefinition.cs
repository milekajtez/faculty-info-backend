using FacultyInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context.ModelDefinitions
{
    public class SubjectProfessorsModelDefinition
    {
        public static void SetModelDefinition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectProfessors>()
                .HasKey(sp => new { sp.SubjectId, sp.ProfessorId });

            modelBuilder.Entity<SubjectProfessors>()
                .HasOne(sp => sp.Subject)
                .WithMany(sp => sp.SubjectProfessors)
                .HasForeignKey(sp => sp.SubjectId);

            modelBuilder.Entity<SubjectProfessors>()
                .HasOne(sp => sp.Professor)
                .WithMany(sp => sp.SubjectProfessors)
                .HasForeignKey(sp => sp.ProfessorId);
        }
    }
}
