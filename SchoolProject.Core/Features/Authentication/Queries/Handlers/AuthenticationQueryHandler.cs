using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler, IRequestHandler<AuthorizeUserQuery, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authenticationService) : base(localizer)
        {
            _localizer = localizer;
            _authenticationService = authenticationService;
        }

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return GenerateSuccessResponse<string>(_localizer[SharedResourcesKeys.TokenIsNotExpired]);
            return GenerateUnauthorizedResponse<string>(_localizer[SharedResourcesKeys.TokenIsExpired]);
        }
    }
}
