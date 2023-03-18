using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context.ModelDefinitions;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudents> CourseStudents { get; set; }
        public DbSet<CourseSubjects> CourseSubjects { get; set; }
        public DbSet<FacultyAdmin> FacultyAdmins { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<MainAdmin> MainAdmins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectProfessors> SubjectProfessors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Security> Securities { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            AttachmentModelDefinition.SetModelDefinition(modelBuilder);
            CommentModelDefinition.SetModelDefinition(modelBuilder);
            CoursesModelDefinition.SetModelDefinition(modelBuilder);
            CourseStudentsModelDefinition.SetModelDefinition(modelBuilder);
            CourseSubjectsModelDefinition.SetModelDefinition(modelBuilder);
            FacultyAdminModelDefinition.SetModelDefinition(modelBuilder);
            FacultyModelDefinition.SetModelDefinition(modelBuilder);
            LikeModelDefinition.SetModelDefinition(modelBuilder);
            MainAdminModelDefinition.SetModelDefinition(modelBuilder);
            PostModelDefinition.SetModelDefinition(modelBuilder);
            ProfessorModelDefinition.SetModelDefinition(modelBuilder);
            StudentModelDefinition.SetModelDefinition(modelBuilder);
            SubjectProfessorsModelDefinition.SetModelDefinition(modelBuilder);
            SubjectModelDefinition.SetModelDefinition(modelBuilder);
            SecurityModelDefinition.SetModelDefinition(modelBuilder);
        }
    }
}
