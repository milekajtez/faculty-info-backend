using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries;
using FacultyInfo.Infrastructure.Repositories;

namespace FacultyInfo.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        #region Queries
        private IAttachmentQuery _attachmentQuery;
        private ICommentQuery _commentQuery;
        private ICourseQuery _courseQuery;
        private ICourseStudentsQuery _courseStudentsQuery;
        private ICourseSubjectsQuery _courseSubjectsQuery;
        private IFacultyAdminQuery _facultyAdminQuery;
        private IFacultyQuery _facultyQuery;
        private ILikeQuery _likeQuery;
        private IMainAdminQuery _mainAdminQuery;
        private IPostQuery _postQuery;
        private IProfessorQuery _professorQuery;
        private IStudentQuery _studentQuery;
        private ISubjectProfessorsQuery _subjectProfessorsQuery;
        private ISubjectQuery _subjectQuery;
        #endregion

        #region Repositories
        private IAttachmentRepository _attachmentRepository;
        private ICommentRepository _commentRepository;
        private ICourseRepository _courseRepository;
        private ICourseStudentsRepository _courseStudentsRepository;
        private ICourseSubjectsRepository _courseSubjectsRepository;
        private IFacultyAdminRepository _facultyAdminRepository;
        private IFacultyRepository _facultyRepository;
        private ILikeRepository _likeRepository;
        private IMainAdminRepository _mainAdminRepository;
        private IPostRepository _postRepository;
        private IProfessorRepository _professorRepository;
        private IStudentRepository _studentRepository;
        private ISubjectProfessorsRepository _subjectProfessorsRepository;
        private ISubjectRepository _subjectRepository;
        #endregion

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Queries
        public IAttachmentQuery AttachmentQuery => _attachmentQuery ??= new AttachmentQuery(_dataContext);
        public ICommentQuery CommentQuery => _commentQuery ??= new CommentQuery(_dataContext);
        public ICourseQuery CourseQuery => _courseQuery ??= new CourseQuery(_dataContext);
        public ICourseStudentsQuery CourseStudentsQuery => _courseStudentsQuery ??= new CourseStudentsQuery(_dataContext);
        public ICourseSubjectsQuery CourseSubjectsQuery => _courseSubjectsQuery ??= new CourseSubjectsQuery(_dataContext);
        public IFacultyAdminQuery FacultyAdminQuery => _facultyAdminQuery ??= new FacultyAdminQuery(_dataContext);
        public IFacultyQuery FacultyQuery => _facultyQuery ??= new FacultyQuery(_dataContext);
        public ILikeQuery LikeQuery => _likeQuery ??= new LikeQuery(_dataContext);
        public IMainAdminQuery MainAdminQuery => _mainAdminQuery ??= new MainAdminQuery(_dataContext);
        public IPostQuery PostQuery => _postQuery ??= new PostQuery(_dataContext);
        public IProfessorQuery ProfessorQuery => _professorQuery ??= new ProfessorQuery(_dataContext);
        public IStudentQuery StudentQuery => _studentQuery ??= new StudentQuery(_dataContext);
        public ISubjectProfessorsQuery SubjectProfessorsQuery => _subjectProfessorsQuery ??= new SubjectProfessorsQuery(_dataContext);
        public ISubjectQuery SubjectQuery => _subjectQuery ??= new SubjectQuery(_dataContext);
        #endregion

        #region Repositories
        public IAttachmentRepository AttachmentRepository => _attachmentRepository ??= new AttachmentRepository(_dataContext);
        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_dataContext);
        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_dataContext);
        public ICourseStudentsRepository CourseStudentsRepository => _courseStudentsRepository ??= new CourseStudentsRepository(_dataContext);
        public ICourseSubjectsRepository CourseSubjectsRepository => _courseSubjectsRepository ??= new CourseSubjectsRepository(_dataContext);
        public IFacultyAdminRepository FacultyAdminRepository => _facultyAdminRepository ??= new FacultyAdminRepository(_dataContext);
        public IFacultyRepository FacultyRepository => _facultyRepository ??= new FacultyRepository(_dataContext);
        public ILikeRepository LikeRepository => _likeRepository ??= new LikeRepository(_dataContext);
        public IMainAdminRepository MainAdminRepository => _mainAdminRepository ??= new MainAdminRepository(_dataContext);
        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_dataContext);
        public IProfessorRepository ProfessorRepository => _professorRepository ??= new ProfessorRepository(_dataContext);
        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_dataContext);
        public ISubjectProfessorsRepository SubjectProfessorsRepository => _subjectProfessorsRepository ??= new SubjectProfessorsRepository(_dataContext);
        public ISubjectRepository SubjectRepository => _subjectRepository ??= new SubjectRepository(_dataContext);
        #endregion

        public async Task<int> CompleteAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
