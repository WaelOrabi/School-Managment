using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrastructure.Abstracts
{
    public interface IStudentSubjectRepository:IGenericRepositoryAsync<StudentSubject>
    {
    }
}
