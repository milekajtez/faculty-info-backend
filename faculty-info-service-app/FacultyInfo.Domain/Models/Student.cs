namespace FacultyInfo.Domain.Models
{
    public class Student : User
    {
        public string PhotoUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<CourseStudents> CourseStudents { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
