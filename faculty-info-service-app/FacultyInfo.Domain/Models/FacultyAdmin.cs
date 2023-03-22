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

        public void Init(Guid id, DateTime created, DateTime updated, string email, string firstName, string lastName, Guid facultyId) 
        {
            Id = id;
            Created = created;
            Updated = updated;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            FacultyId = facultyId;
        }
    }
}
