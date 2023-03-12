namespace FacultyInfo.Domain.Models
{
    public class Post : Entity
    {
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid? FacultyAdminId { get; set; }
        public FacultyAdmin FacultyAdmin { get; set; }
        public Guid? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
