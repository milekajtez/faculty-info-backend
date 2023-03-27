namespace FacultyInfo.Domain.Models
{
    public class Faculty : Entity
    {
        public string Tin { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<FacultyAdmin> FacultyAdmins { get; set; }
        public ICollection<Course> Courses { get; set; }

        public void Init(Guid id, DateTime created, DateTime updated, string tin, string name, string description, string location) 
        {
            Id = id;
            Created = created;
            Updated = updated;
            Tin = tin;
            Name = name;
            Description = description;
            Location = location;
        }
    }
}
