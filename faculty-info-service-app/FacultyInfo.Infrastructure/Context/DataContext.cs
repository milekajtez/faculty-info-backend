using FacultyInfo.Domain.Models.ModelsForUsers;
using FacultyInfo.Infrastructure.Context.ModelDefinitions;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DbSet<MainAdmin> MainAdmins { get; set; }
        public DbSet<DepartmentAdmin> DepartmentAdmins { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            MainAdminModelDefinition.SetModelDefinition(modelBuilder);
            DepartmentAdminModelDefinition.SetModelDefinition(modelBuilder);
            ProfessorModelDefinition.SetModelDefinition(modelBuilder);
            StudentModelDefinition.SetModelDefinition(modelBuilder);
            SecurityModelDefinition.SetModelDefinition(modelBuilder);
        }
    }
}
