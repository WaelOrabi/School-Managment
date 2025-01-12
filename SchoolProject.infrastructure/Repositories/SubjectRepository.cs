using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields

        #endregion
        #region Constructors
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        #endregion
        #region Handle Functions
        #endregion
    }
}
