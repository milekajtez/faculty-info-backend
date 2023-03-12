﻿using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class StudentQuery : BaseQuery<Student>, IStudentQuery
    {
        public StudentQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
