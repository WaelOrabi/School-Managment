using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Validatiors
{
    public class AddRoleCommandValidator : AbstractValidator<AddRoleCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion
        #region Constructors
        public AddRoleCommandValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplayValidationRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplayValidationRules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName).MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key))
                                    .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
