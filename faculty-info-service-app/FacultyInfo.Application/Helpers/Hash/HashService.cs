using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FacultyInfo.Application.Helpers.Hash
{
    public class HashService : IHashService
    {
        private readonly IConfiguration _configuration;

        public HashService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string ConvertStringToHash(string text)
        {
            if (string.IsNullOrEmpty(text)) 
                throw new ConversionException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.ConversionToHashInvalid, Array.Empty<string>()));

            var algo = HashAlgorithm.Create(_configuration["HASH_METHOD"]);
            var hash = algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }

        public string GenerateToken(string email, string userRole) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_KEY"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, userRole)
            };

            var token = new JwtSecurityToken(
                _configuration["JWT_ISSUER"],
                _configuration["JWT_AUDIENCE"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
