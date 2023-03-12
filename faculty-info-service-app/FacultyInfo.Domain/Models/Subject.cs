namespace FacultyInfo.Domain.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CourseSubjects> CourseSubjects { get; set; }
        public ICollection<SubjectProfessors> SubjectProfessors { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
