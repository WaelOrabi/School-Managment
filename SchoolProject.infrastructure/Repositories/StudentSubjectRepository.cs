using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrastructure.Repositories
{
    public class StudentSubjectRepository : GenericRepositoryAsync<StudentSubject>, IStudentSubjectRepository
    {
        public StudentSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
