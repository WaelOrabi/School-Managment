using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields

        #endregion
        #region Constructors
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        #endregion
        #region Handle Functions
        #endregion
    }
}
