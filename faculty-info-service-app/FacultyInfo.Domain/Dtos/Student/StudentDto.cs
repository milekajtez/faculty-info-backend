namespace FacultyInfo.Domain.Dtos.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Init(Guid id, string username, string firstname, string lastname, string email) 
        {
            Id = id;
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
    }
}
