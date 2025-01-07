using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Commands.Validations
{
    public class SigninValidators : AbstractValidator<SiginCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResourcesKeys> _localizer;
        #endregion
        #region Constructors
        public SigninValidators(IStringLocalizer<SharedResourcesKeys> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                                    .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Password).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        #endregion
    }
}
