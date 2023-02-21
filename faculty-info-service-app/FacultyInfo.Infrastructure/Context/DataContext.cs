using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context.ModelDefinitions;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Security> Securities { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            UserModelDefinition.SetModelDefinition(modelBuilder);
            SecurityModelDefinition.SetModelDefinition(modelBuilder);
        }
    }
}
