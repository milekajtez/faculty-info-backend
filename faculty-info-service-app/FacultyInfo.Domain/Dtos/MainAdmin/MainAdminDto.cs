namespace FacultyInfo.Domain.Dtos.MainAdmin
{
    public class MainAdminDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
