using FacultyInfo.Domain.Enums.User;

namespace FacultyInfo.Domain.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserType UserType { get; set; }
        public ProfessorType ProfessorType { get; set; }
        public FinanceType FinanceType { get; set; }
        public Guid SecurityId { get; set; }
        public Security Security { get; set; }
    }
}
