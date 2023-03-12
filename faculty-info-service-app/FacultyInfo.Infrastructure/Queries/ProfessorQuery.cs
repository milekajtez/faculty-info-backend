﻿using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class ProfessorQuery : BaseQuery<Professor>, IProfessorQuery
    {
        public ProfessorQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
