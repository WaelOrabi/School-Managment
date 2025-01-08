using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Responses;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SiginCommandModel, Response<JWTAuthResponse>>,
                                                                 IRequestHandler<RefreshTokenCommandModel, Response<JWTAuthResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _sigInManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService) : base(localizer)
        {
            _localizer = localizer;
            _userManager = userManager;
            _sigInManager = signInManager;
            _authenticationService = authenticationService;
        }

        public async Task<Response<JWTAuthResponse>> Handle(SiginCommandModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return GenerateBadRequestResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.UserNameIsNotExist]);
            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true; // Set EmailConfirmed to true
                var updateResult = await _userManager.UpdateAsync(user); // Save the change to the database
                if (!updateResult.Succeeded)
                {
                    return GenerateBadRequestResponse<JWTAuthResponse>("Failed to update EmailConfirmed property");
                }
            }
            var signInResult = await _sigInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
                return GenerateBadRequestResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.PasswordNotCorrect]);
            var result = await _authenticationService.GetJWTToken(user);
            return GenerateSuccessResponse<JWTAuthResponse>(result);
        }

        public async Task<Response<JWTAuthResponse>> Handle(RefreshTokenCommandModel request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);

            var (userId, userRefreshToken) = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);

            switch (userId, userRefreshToken)
            {
                case ("AlgorithmIsWrong", null): return GenerateUnauthorizedResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.AlgorithmIsWrong]);
                case ("TokenIsNotExpired", null): return GenerateUnauthorizedResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("RefreshTokenIsNotFound", null): return GenerateUnauthorizedResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("RefreshTokenIsExpired", null): return GenerateUnauthorizedResponse<JWTAuthResponse>(_localizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return GenerateNotFoundResponse<JWTAuthResponse>();

            var result = await _authenticationService.GetRefreshToken(user, jwtToken, userRefreshToken, request.RefreshToken);

            return GenerateSuccessResponse(result);
        }
    }
}
