﻿using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class CourseSubjectsRepository : BaseRepository<CourseSubjects>, ICourseSubjectsRepository
    {
        public CourseSubjectsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
