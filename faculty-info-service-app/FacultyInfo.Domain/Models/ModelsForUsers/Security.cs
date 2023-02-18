namespace FacultyInfo.Domain.Models.ModelsForUsers
{
    public class Security : Entity
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
    }
}
