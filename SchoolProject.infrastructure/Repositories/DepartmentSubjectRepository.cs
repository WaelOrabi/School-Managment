using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class DepartmentSubjectRepository : GenericRepositoryAsync<DepartmentSubject>, IDepartmentSubjectRepository
    {
        public DepartmentSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
