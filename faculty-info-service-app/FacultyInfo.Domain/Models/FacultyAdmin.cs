namespace FacultyInfo.Domain.Models
{
    public class FacultyAdmin : User
    {
        public string PhotoUrl { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
