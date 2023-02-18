namespace FacultyInfo.Domain.Models.ModelsForUsers
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid SecurityId { get; set; }
        public Security Security { get; set; }
    }
}
