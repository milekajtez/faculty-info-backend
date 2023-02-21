namespace FacultyInfo.Domain.Models
{
    public class Security : Entity
    {
        public string Password { get; set; }
        public User User { get; set; }
    }
}
