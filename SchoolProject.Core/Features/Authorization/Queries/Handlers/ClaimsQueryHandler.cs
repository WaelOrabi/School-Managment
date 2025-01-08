using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Responses;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler, IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>
    {
        #region Fileds
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructor
        public ClaimsQueryHandler(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager, IAuthorizationService authorizationService) : base(localizer)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        #endregion
        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return GenerateNotFoundResponse<ManageUserClaimsResponse>(_localizer[SharedResourcesKeys.UserNotFound]);
            var result = await _authorizationService.ManageUserClaimsData(user);
            return GenerateSuccessResponse(result);
        }
    }
}
