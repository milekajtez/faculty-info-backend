using FacultyInfo.Domain.Dtos.MainAdmin;
using MediatR;

namespace FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin
{
    public class RegisterMainAdminCommand : IRequest<MainAdminDto>
    {
    }
}
