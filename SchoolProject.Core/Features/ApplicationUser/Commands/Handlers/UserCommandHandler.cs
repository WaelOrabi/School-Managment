using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommandModel, Response<string>>,
                                                       IRequestHandler<EditUserCommandModel, Response<string>>,
                                                       IRequestHandler<DeleteUserCommandModel, Response<string>>,
                                                       IRequestHandler<ChangeUserPasswordCommand, Response<string>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public UserCommandHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, UserManager<User> userManager) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommandModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
                return GenerateBadRequestResponse<string>(_localizer[SharedResourcesKeys.EmailIsExist]);
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName != null)
                return GenerateBadRequestResponse<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);
            var identityUser = _mapper.Map<User>(request);
            var createResult = await _userManager.CreateAsync(identityUser, request.Password);
            if (!createResult.Succeeded)
                return GenerateBadRequestResponse<string>(createResult.Errors.FirstOrDefault().Description);
            return GenerateCreatedResponse<string>("");
        }

        public async Task<Response<string>> Handle(EditUserCommandModel request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (oldUser == null) return GenerateNotFoundResponse<string>();
            var newUser = _mapper.Map(request, oldUser);
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            if (userByUserName != null)
                return GenerateBadRequestResponse<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);
            var result = await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return GenerateBadRequestResponse<string>(_localizer[SharedResourcesKeys.UpdateFailed]);
            return GenerateSuccessResponse<string>(_localizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommandModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return GenerateNotFoundResponse<string>();
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return GenerateBadRequestResponse<string>(_localizer[SharedResourcesKeys.DeletedFailed]);
            return GenerateDeletedResponse<string>();

        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return GenerateNotFoundResponse<string>();
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //     await _userManager.RemovePasswordAsync(user);
            //     await _userManager.AddPasswordAsync(user, request.NewPassword);
            if (!result.Succeeded) return GenerateBadRequestResponse<string>(result.Errors.FirstOrDefault().Description);
            return GenerateSuccessResponse<string>("");
        }
        #endregion
    }
}
