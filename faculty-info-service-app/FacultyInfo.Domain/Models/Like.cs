namespace FacultyInfo.Domain.Models
{
    public class Like : Entity
    {
        public Guid? PostId { get; set; }
        public Post Post { get; set; }
        public Guid? CommentId { get; set; }
        public Comment Comment { get; set; }
        public Guid? FacultyAdminId { get; set; }
        public FacultyAdmin FacultyAdmin { get; set; }
        public Guid? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
