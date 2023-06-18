using FacultyInfo.Domain.Enums.User;
using MediatR;

namespace FacultyInfo.Application.Users.Queries.Login;

public sealed record LoginQuery(string Email, string Password) : IRequest<string>;
