using FacultyInfo.Domain.Dtos.Faculty;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FacultyInfo.Application.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommand : IRequest<FacultyDto>
    {
        [Required]
        [StringLength(10)]
        public string Tin { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
