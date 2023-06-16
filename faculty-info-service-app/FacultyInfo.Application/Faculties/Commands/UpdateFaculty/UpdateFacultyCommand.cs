using FacultyInfo.Domain.Dtos.Faculty;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FacultyInfo.Application.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommand : IRequest<FacultyDto>
    {
        [Required]
        public Guid Id { get; set; }
        
        [StringLength(10)]
        public string Tin { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Location { get; set; }
    }
}
