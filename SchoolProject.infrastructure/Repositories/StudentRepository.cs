using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields

        #endregion

        #region Constructors
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region Handles Functions

        #endregion

    }
}
