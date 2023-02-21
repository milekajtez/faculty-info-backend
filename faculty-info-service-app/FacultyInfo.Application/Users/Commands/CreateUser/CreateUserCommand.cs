using FacultyInfo.Domain.Dtos.User;
using FacultyInfo.Domain.Enums.User;
using MediatR;

namespace FacultyInfo.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public FinanceType? FinanceType { get; set; }
        public ProfessorType? ProfessorType { get; set; }
    }
}
