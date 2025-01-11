using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class InstructorSubjectRepository : GenericRepositoryAsync<InstructorSubject>, IInstructorSubjectRepository
    {
        public InstructorSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
