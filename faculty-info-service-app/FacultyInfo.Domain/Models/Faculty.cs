namespace FacultyInfo.Domain.Models
{
    public class Faculty : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<FacultyAdmin> FacultyAdmins { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
