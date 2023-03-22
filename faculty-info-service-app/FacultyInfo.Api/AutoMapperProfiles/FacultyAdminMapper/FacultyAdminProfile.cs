using AutoMapper;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Models;

namespace FacultyInfo.Api.AutoMapperProfiles.FacultyAdminMapper
{
    public class FacultyAdminProfile : Profile
    {
        public FacultyAdminProfile()
        {
            CreateMap<FacultyAdmin, FacultyAdminDto>();
        }
    }
}
