namespace FacultyInfo.Domain.Dtos.FacultyAdmin
{
    public class FacultyAdminDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public Guid FacultyId { get; set; }
    }
}
