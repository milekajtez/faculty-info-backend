namespace FacultyInfo.Application.Helpers.Hash
{
    public interface IHashService
    {
        string ConvertStringToHash(string text);
        string GenerateToken(string email, string userRole);
    }
}
