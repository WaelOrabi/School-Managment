using SchoolProject.Data.Entities.Identity;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
