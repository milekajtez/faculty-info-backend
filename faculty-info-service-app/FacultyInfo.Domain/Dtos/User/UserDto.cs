namespace FacultyInfo.Domain.Dtos.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public void Init(Guid userId, string username, string token) 
        {
            UserId = userId;
            UserName = username;
            Token = token;
        }
    }
}
