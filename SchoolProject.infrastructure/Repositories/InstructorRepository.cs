using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields

        #endregion
        #region Constructors
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        #endregion
        #region Handle Functions
        #endregion
    }
}
