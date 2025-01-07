using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;
        #endregion
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
