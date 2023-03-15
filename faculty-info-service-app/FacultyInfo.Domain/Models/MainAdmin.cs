namespace FacultyInfo.Domain.Models
{
    public class MainAdmin : User
    {
        public void Init(
            Guid id, 
            DateTime created, 
            DateTime updated, 
            string username, 
            string email, 
            string firstName, 
            string lastName, 
            string passwordHash) 
        {
            Id = id;
            Created = created;
            Updated = updated;
            UserName = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PasswordValue = passwordHash;
        }
    }
}
