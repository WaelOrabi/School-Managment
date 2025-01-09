using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler, IRequestHandler<AddRoleCommandModel, Response<string>>,
                                                       IRequestHandler<EditRoleCommandModel, Response<string>>,
                                                       IRequestHandler<DeleteRoleCommand, Response<string>>,
                                                       IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public RoleCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddRoleCommandModel request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Success")
                return GenerateSuccessResponse("");
            return GenerateBadRequestResponse<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
        }

        public async Task<Response<string>> Handle(EditRoleCommandModel request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request);
            var result = await _authorizationService.EditRoleAsync(role);
            if (result == "notFound") return GenerateNotFoundResponse<string>();
            else if (result == "Success") return GenerateSuccessResponse<string>(_stringLocalizer[SharedResourcesKeys.Updated]);
            else
                return GenerateBadRequestResponse<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);
            if (result == "NotFound")
                return GenerateNotFoundResponse<string>();
            else if (result == "Used")
                return GenerateBadRequestResponse<string>(_stringLocalizer[SharedResourcesKeys.RoleIsUsed]);
            else if (result == "Success")
                return GenerateSuccessResponse<string>(_stringLocalizer[SharedResourcesKeys.Deleted]);
            else
                return GenerateBadRequestResponse<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "UserIsNull": return GenerateNotFoundResponse<string>(_stringLocalizer[SharedResourcesKeys.UserNotFound]);
                case "FailedToRemoveOldRoles": return GenerateBadRequestResponse<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "FailedToAddNewRoles": return GenerateBadRequestResponse<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "FailedToUpdateUserRoles": return GenerateBadRequestResponse<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateUserRoles]);
            }
            return GenerateSuccessResponse<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }
        #endregion
    }
}
