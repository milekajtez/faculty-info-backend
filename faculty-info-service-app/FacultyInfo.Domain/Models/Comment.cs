namespace FacultyInfo.Domain.Models
{
    public class Comment : Entity
    {
        public string Description { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public Guid? FacultyAdminId { get; set; }
        public FacultyAdmin FacultyAdmin { get; set; }
        public Guid? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
