using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Responses;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler, IRequestHandler<GetRolesListQuery, Response<List<GetRoleResponse>>>,
                                                   IRequestHandler<GetRoleByIdQuery, Response<GetRoleResponse>>,
                                                   IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        #endregion
        #region Constructor
        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager, IAuthorizationService authorizationService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetRoleResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRoleResponse>>(roles);
            return GenerateSuccessResponse(result);
        }

        public async Task<Response<GetRoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            if (role == null)
                return GenerateNotFoundResponse<GetRoleResponse>(_stringLocalizer[SharedResourcesKeys.RoleNotFound]);
            return GenerateSuccessResponse(_mapper.Map<GetRoleResponse>(role));
        }

        public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return GenerateNotFoundResponse<ManageUserRolesResponse>(_stringLocalizer[SharedResourcesKeys.UserNotFound]);
            var result = await _authorizationService.ManagerUserRolesData(user);
            return GenerateSuccessResponse(result);
        }
        #endregion
    }
}
