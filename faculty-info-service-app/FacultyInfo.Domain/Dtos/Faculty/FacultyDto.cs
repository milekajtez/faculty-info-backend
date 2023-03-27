namespace FacultyInfo.Domain.Dtos.Faculty
{
    public class FacultyDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
