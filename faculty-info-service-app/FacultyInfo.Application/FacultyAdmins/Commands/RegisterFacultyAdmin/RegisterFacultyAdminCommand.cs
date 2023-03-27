using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommand : IRequest<FacultyAdminDto>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public Guid FacultyId { get; set; }
    }
}
