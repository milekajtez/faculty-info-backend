using FacultyInfo.Domain.Enums.Course;

namespace FacultyInfo.Domain.Models
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInfo { get; set; }
        public CourseType CourseType { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<CourseStudents> CourseStudents { get; set; }
        public ICollection<CourseSubjects> CourseSubjects { get; set; }
    }
}
