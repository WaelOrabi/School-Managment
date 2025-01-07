using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JWTAuthResult> GetJWTToken(User user);
        public Task<JWTAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, UserRefreshToken? userRefreshToken, string refreshToken);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, UserRefreshToken?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
    }
}
