namespace FacultyInfo.Domain.Models.ModelsForUsers
{
    public class DepartmentAdmin : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
