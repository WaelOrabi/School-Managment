using SchoolProject.Data.Entities.Identity;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields

        #endregion
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
