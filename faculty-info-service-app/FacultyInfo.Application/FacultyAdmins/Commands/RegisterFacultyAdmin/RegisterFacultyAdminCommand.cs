using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;

namespace FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommand : IRequest<FacultyAdminDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid FacultyId { get; set; }
    }
}
