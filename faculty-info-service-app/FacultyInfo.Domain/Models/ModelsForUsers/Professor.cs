using FacultyInfo.Domain.Enums.User;

namespace FacultyInfo.Domain.Models.ModelsForUsers
{
    public class Professor : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ProfessorType ProfessorType { get; set; }
    }
}
