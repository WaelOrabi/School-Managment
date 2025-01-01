using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public AddUserCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplayValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
            .MaximumLength(100).WithMessage("Max Length is 100");
            RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
            .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.Email).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
           .MaximumLength(100).WithMessage("{PropertyName} Length is 100");

            RuleFor(x => x.Password).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword]);
        }

        #endregion
    }
}
