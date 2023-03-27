using AutoMapper;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Models;

namespace FacultyInfo.Api.AutoMapperProfiles.FacultyMapper
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, FacultyDto>();
        }
    }
}
