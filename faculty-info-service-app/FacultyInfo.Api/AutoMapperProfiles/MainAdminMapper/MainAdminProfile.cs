using AutoMapper;
using FacultyInfo.Domain.Dtos.MainAdmin;
using FacultyInfo.Domain.Models;

namespace FacultyInfo.Api.AutoMapperProfiles.MainAdminMapper
{
    public class MainAdminProfile : Profile
    {
        public MainAdminProfile() 
        {
            CreateMap<MainAdmin, MainAdminDto>();
        }
    }
}
