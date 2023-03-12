namespace FacultyInfo.Domain.Models
{
    public class CourseSubjects
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
