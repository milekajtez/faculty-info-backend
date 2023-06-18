using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Abstractions.Repositories;

namespace FacultyInfo.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Queries
        IAttachmentQuery AttachmentQuery { get; }
        ICommentQuery CommentQuery { get; }
        ICourseQuery CourseQuery { get; }
        ICourseStudentsQuery CourseStudentsQuery { get; }
        ICourseSubjectsQuery CourseSubjectsQuery { get; }
        IFacultyAdminQuery FacultyAdminQuery { get; }
        IFacultyQuery FacultyQuery { get; }
        ILikeQuery LikeQuery { get; }
        IMainAdminQuery MainAdminQuery { get; }
        IPostQuery PostQuery { get; }
        IProfessorQuery ProfessorQuery { get; }
        IStudentQuery StudentQuery { get; }
        ISubjectProfessorsQuery SubjectProfessorsQuery { get; }
        ISubjectQuery SubjectQuery { get; }
        #endregion

        #region Repositories
        IAttachmentRepository AttachmentRepository { get; }
        ICommentRepository CommentRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICourseStudentsRepository CourseStudentsRepository { get; }
        ICourseSubjectsRepository CourseSubjectsRepository { get; }
        IFacultyAdminRepository FacultyAdminRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        ILikeRepository LikeRepository { get; }
        IMainAdminRepository MainAdminRepository { get; }
        IPostRepository PostRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectProfessorsRepository SubjectProfessorsRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        #endregion

        Task<int> CompleteAsync();
    }
}
