﻿using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JWTAuthResponse> GetJWTToken(User user);
        public Task<JWTAuthResponse> GetRefreshToken(User user, JwtSecurityToken jwtToken, UserRefreshToken? userRefreshToken, string refreshToken);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, UserRefreshToken?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
    }
}
