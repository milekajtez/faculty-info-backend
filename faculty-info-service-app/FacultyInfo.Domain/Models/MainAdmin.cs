namespace FacultyInfo.Domain.Models
{
    public class MainAdmin : User
    {
        public void Init(Guid id, DateTime created, DateTime updated, string email, string firstName, string lastName) 
        {
            Id = id;
            Created = created;
            Updated = updated;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
