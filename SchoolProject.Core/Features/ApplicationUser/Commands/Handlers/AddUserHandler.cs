using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommandModel, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public AddUserHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, UserManager<User> userManager) : base(localizer)
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
        #endregion
    }
}
