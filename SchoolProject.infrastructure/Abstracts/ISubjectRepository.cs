﻿using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Abstracts
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
    }
}
