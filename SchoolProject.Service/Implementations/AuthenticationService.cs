using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;

        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;

            _refreshTokenRepository = refreshTokenRepository;

        }
        #endregion
        #region Handle Functions
        public async Task<JWTAuthResult> GetJWTToken(User user)
        {

            var (jwtToken, accessToken) = GenerateJwtToken(user);

            var refreshToken = GetRefreshToken(user.UserName);
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = accessToken,
                UserId = user.Id,
            };
            await _refreshTokenRepository.AddAsync(userRefreshToken);
            return new JWTAuthResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        private (JwtSecurityToken, string) GenerateJwtToken(User user)
        {
            var jwtToken = new JwtSecurityToken(
         _jwtSettings.Issuer,
         _jwtSettings.Audience,
         GetClaims(user),
         expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
         signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
         );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = userName,
                TokenString = GenerateRefreshToken()
            };

            return refreshToken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>() {
            new Claim(nameof(UserClaimModel.UserName), user.UserName),
            new Claim(nameof(UserClaimModel.Email), user.Email),
            new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
                 new Claim(nameof(UserClaimModel.Id), user.Id.ToString())
            };
            return claims;
        }

        public async Task<JWTAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, UserRefreshToken? userRefreshToken, string refreshToken)
        {
            var (jwtSecurityToken, newToken) = GenerateJwtToken(user);
            var response = new JWTAuthResult();
            response.AccessToken = newToken;
            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = userRefreshToken.ExpiryDate;
            response.RefreshToken = refreshTokenResult;
            //add new row in table refreshtoken 
            //userRefreshToken.Id = 0;
            //userRefreshToken.Token = newToken;
            // await _refreshTokenRepository.AddAsync(userRefreshToken);
            userRefreshToken.Token = newToken;
            await _refreshTokenRepository.UpdateAsync(userRefreshToken);
            return response;
        }

        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = _jwtSettings.ValidateLifetime,
            };

            var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
            if (validator == null)
                return "InvalidToken";
            return "NotExpired";

        }

        public async Task<(string, UserRefreshToken?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                return ("AlgorithmIsWrong", null);
            if (jwtToken.ValidTo > DateTime.UtcNow)
                return ("TokenIsNotExpired", null);
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Token == accessToken && x.RefreshToken == refreshToken && x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
                return ("RefreshTokenIsNotFound", null);
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshTokenIsExpired", null);
            }

            return (userId, userRefreshToken);
        }
        #endregion

    }
}
