using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplayValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
               .Equal(x => x.NewPassword).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);
        }

        #endregion
    }
}

