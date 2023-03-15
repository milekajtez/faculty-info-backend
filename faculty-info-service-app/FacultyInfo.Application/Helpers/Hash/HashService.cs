using Microsoft.Extensions.Configuration;
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
            if (string.IsNullOrEmpty(text)) return string.Empty;

            var algo = HashAlgorithm.Create(_configuration["HASH_METHOD"]);
            var hash = algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            return BitConverter.ToString(hash);
        }
    }
}
