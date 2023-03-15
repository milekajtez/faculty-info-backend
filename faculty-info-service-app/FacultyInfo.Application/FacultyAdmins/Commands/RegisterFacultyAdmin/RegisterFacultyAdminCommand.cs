using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommand : IRequest<FacultyAdminDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Photo { get; set; }
        public Guid FacultyId { get; set; }
    }
}
