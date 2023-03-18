using FacultyInfo.Domain.Enums.User;

namespace FacultyInfo.Domain.Models
{
    public class Security : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public void Init(Guid id, DateTime created, DateTime updated, string email, string password, UserType userType)
        {
            Id = id;
            Created = created;
            Updated = updated;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
