using FacultyInfo.Domain.Enums.User;

namespace FacultyInfo.Domain.Models
{
    public class Professor : User
    {
        public string PhotoUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ProfessorType ProfessorType { get; set; }
        public ICollection<SubjectProfessors> SubjectProfessors { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
