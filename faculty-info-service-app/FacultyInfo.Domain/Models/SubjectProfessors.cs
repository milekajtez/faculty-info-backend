namespace FacultyInfo.Domain.Models
{
    public class SubjectProfessors
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
